using CompanionAppShared;
using CompanionAppShared.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DataBaseConnector;

public class DataBase
{
	public event EventHandler UIUpdateRequestedFromDB;
	public List<Patient> Patients = new List<Patient>();
	public bool IsLoading = false;

	public event EventHandler<Exception> ErrorOccurred;

	private readonly ISQLDataAccess db;

	#region init

	public bool HasError = false;
	public Exception? error = null;


	public DataBase(ISQLDataAccess _db)
	{
		db = _db;
		db.OnNewError += HandleError;
		db.ErrorCleared += ClearError;
	}

	private void ClearError(object? sender, EventArgs e)
	{
		HasError = false;
	}

	private void HandleError(object? sender, Exception e)
	{
		IsLoading = false;
		HasError = true;
		error = e;
		ErrorOccurred?.Invoke(this, e);
	}

	private bool AlreadyInitialized = false;

	public void Init()
	{
		if (AlreadyInitialized) return;

		AlreadyInitialized = true;
		Task.Run(async () => await LoadListOfPatients());
	}
	#endregion

	#region patients

	public async Task LoadListOfPatients()
	{
		IsLoading = true;
		Update();
		Patients = (await GetPatients())?.ToList() ?? new();
		IsLoading = false;
		Update();
	}

	public async Task SelectPatient(SelectedItems Current)
	{
		if (Current.SelectedPatient is not null && !Current.SelectedPatient.IsFullyLoadedFromDB)
		{
			Current.SelectedPatient =
				await GetPatient(Current.SelectedPatient.Id) ??
				new Patient { PatientLabel = "Not Found" };

			Current.SelectedTherapy = Current.SelectedPatient.GetParkinsonTherapy();

			var oldP = Patients.Find(x=>x.PatientLabel == Current.SelectedPatient.PatientLabel);
			Patients.Remove(oldP);
			Patients.Add(Current.SelectedPatient);
		}
	}

	private void Update() => UIUpdateRequestedFromDB?.Invoke(this, EventArgs.Empty);

	/// <summary>
	/// gets a summary of all the patients without the SerializedData field. 
	/// If you want all the info for a given patient you need to call GetPatient afterwards
	/// </summary>
	/// <returns></returns>
	public Task<IEnumerable<Patient>> GetPatients() => db.LoadData<Patient, dynamic>("dbo.spPatient_GetAll", new { });

	/// <summary>
	/// Gets ALL the serialized data for a given patient's ID and deserializes it into a fully fledged patient.
	/// </summary>
	/// <param name="id">The ID of the patient to be retrieved from the DB</param>
	/// <returns></returns>
	public async Task<Patient?> GetPatient(Guid id)
	{
		var results = await db.LoadData<Patient, dynamic>("dbo.spPatient_Get", new { Id = id });
		var r = results.FirstOrDefault();
		var p = Patient.FromJson(r.SerializedData);
		var sessions = await sGetAllMeasurementsSummariesOfTherapy(p.TherapyLabels[0]);
		p.ReconstructTherapyWithSeasons(sessions, p.TherapyLabels[0]);
		p.IsFullyLoadedFromDB = true;

		var OldPatient = Patients.Find(x => x.Id == p.Id);
		if (OldPatient is not null)
		{
			Patients.Remove(OldPatient);
			Patients.Add(p);
		}

		return p;
	}

	public async Task DeleteSession(SelectedItems Current)
	{
		if (Current is not null && Current.SelectedPatient is not null && Current.SelectedTherapy is not null && Current.SelectedSession is not null)
		{ 
			Current.SelectedTherapy.Sessions.Remove(Current.SelectedSession);
			await DeleteSession(Current.SelectedSession);
			Current.SelectedSession = null;
			Current.SelectedScale = null;
		}
	}

	public async Task<bool> CheckIfNameIsAlreadyTaken(Patient p)
	{
		try
		{
			var query = $"SELECT COUNT(*) FROM dbo.Patient WHERE PatientLabel = '{p.PatientLabel}'";
			int existingPatients = await db.Count(query);
			return existingPatients > 0;

		}catch(Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
			return true;
		}

	}

	public async Task InsertPatient(Patient patient)
	{
		
		try
		{
			//var ExistingPatient = Patients.Find(x => x.Id == patient.Id);


			var serialized = patient.Serialize();
			await db.SaveData("dbo.spPatient_Insert",
			new
			{
				Id = patient.Id,
				GymCode = patient.GymCode,
				PatientLabel = patient.PatientLabel,
				NumberOfMeasurementsInLastTherapy = patient.NumberOfSessions,
				LastMeasurementInLastTherapy = patient.LastSession,
				SerializedData = serialized
			});
		}catch(Exception ex) { 
			ErrorOccurred?.Invoke(this, ex);
		}
	}

	public async Task UpdateSelectedPatientToDB(SelectedItems current)
	{
		try
		{
			var LastMeasurementInLastTherapy = "-";

			if ((DateTime?)current.SelectedPatient.LastSession is not null)
				LastMeasurementInLastTherapy = ((DateTime)current.SelectedPatient.LastSession).ToString("dd.MM.yyyy");

			await db.SaveData("dbo.spPatient_Update", new
			{
				Id = current.SelectedPatient.Id,
				Label = current.SelectedPatient.PatientLabel,
				NumberOfMeasurementsInLastTherapy = current.SelectedPatient.NumberOfSessions,
				LastMeasurementInLastTherapy = LastMeasurementInLastTherapy,
				SerializedData = current.SelectedPatient.Serialize()
			});
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	public async Task DeletePatient(Guid id)
	{
		var p = Patients.Find(x => x.Id == id);
		if(p is not null)
		{
			await db.SaveData("dbo.spMeasurement_DeleteAllSessionsOfPatient", new { PatientId = p.PatientLabel });
		}
		await db.SaveData("dbo.spPatient_Delete", new { Id = id });
	}


	public async Task GeneratePatientLabelForSelectedGym(Patient p)
	{
		try
		{
			var query = $"SELECT COUNT(*) FROM dbo.Patient WHERE GymCode = '{p.Gym.ToString()}'";
			int existingPatients = await db.Count(query);
			p.PatientLabel = PatientLabelTools.FormLabel(p.Gym, existingPatients);
		}catch(Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	#endregion

	#region measurements

	/// <summary>
	/// Get all the summary of sessions for a given TherapyLabel. Please remember that the TherapyLabel already contains the patient label. Looks like "ABC.27.RuX.0"
	/// </summary>
	/// <param name="therapyID"></param>
	/// <returns></returns>
	public Task<IEnumerable<Session>> sGetAllMeasurementsSummariesOfTherapy(string therapyID) =>
		db.LoadData<Session, dynamic>("dbo.spMeasurement_GetAllSessionHighlightsFromTherapy", new { TherapyID = therapyID });

	/// <summary>
	/// The NewScale needs to be added to the measurement. The CurrentScale must point to this new item. 
	/// </summary>
	/// <param name="measurement"></param>
	/// <param name="NewScale"></param>
	/// <returns></returns>
	public async Task UpdateScaleInSession(SelectedItems current, IScale NewScale)
	{
		current.SelectedSession.Scales.Remove(current.SelectedScale);
		current.SelectedSession.Scales.Add(NewScale);
		current.SelectedScale = NewScale;

		await StoreSession(current);
	}

	public async Task DeleteScaleInSession(SelectedItems current)
	{
		if(current.SelectedScale is not null)
		{
			current.SelectedScale.Reset();

			await StoreSession(current);
		}
	}

	public async Task StoreSession(SelectedItems Current)
	{
		try
		{
			Current.SelectedSession.GenerateTags();
			var ExistingSession = Current.SelectedTherapy.Sessions.Find(x => x.Id == Current.SelectedSession.Id);
			if (ExistingSession != null)
				ExistingSession = Current.SelectedSession;
			else
				Current.SelectedTherapy.Sessions.Add(Current.SelectedSession);

			var SerializedData = CreateStorableVersionOftheSession(Current.SelectedSession);

			//var SerializedData = System.Text.Json.JsonSerializer.Serialize(Current.SelectedSession.ToDBDictionary());

			await db.SaveData("spMeasurement_InsertOrUpdate",
			new
			{
				Current.SelectedSession.Id,
				Current.SelectedSession.PatientID,
				Current.SelectedSession.SessionID,
				Current.SelectedSession.SessionKind,
				Current.SelectedSession.MeasurementDate,
				Current.SelectedSession.TherapyID,
				Current.SelectedSession.Tag,
				Current.SelectedSession.AccuracyTag,
				SerializedData
			});

			//await UpdateSelectedPatientToDB(Current);
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	private string CreateStorableVersionOftheSession(Session session)
	{
		List<StorableScale> StorableScales = new();
		foreach (var sc in session.Scales)
		{
			StorableScales.Add(new StorableScale
			{
				ScaleID = sc.Id,
				IsMeasured = sc.IsMeasured,
				SimplifiedResults = sc.ToDBDictionary()
			});
		}
		return JsonSerializer.Serialize(StorableScales);
	}

	public class StorableScale
	{
		public ScalesIDs ScaleID { get; set; } = ScalesIDs.NotSet;
		public bool IsMeasured { get; set; }
		public Dictionary<string,string> SimplifiedResults { get; set; } = new();
	}

	public async Task<Session> UpdateSessionInTherapyWithDetailsFromDB(SelectedItems Current)
	{
		try
		{
			var s = await LoadSession(Current);

			var ExistingSession = Current.SelectedTherapy.Sessions.Find(x=>x.Id == Current.SelectedSession.Id);
			if(ExistingSession != null)
			{
				Current.SelectedTherapy.Sessions.Remove(ExistingSession);
				Current.SelectedTherapy.Sessions.Add(Current.SelectedSession);
			}

			return s;
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
			return Current.SelectedSession;
		}
	}

	public async Task<string> GetSummarizedSessionResultsForAPI(Guid id)
	{
		var results = await db.LoadData<Session, dynamic>("dbo.spMeasurement_GetWithData", new
		{
			Id = id,
		});
		var r = results.FirstOrDefault();

		return r.SerializedData;
	}

	public async Task<Session> GetSessionFromDB(Guid id)
	{
		var results = await db.LoadData<Session, dynamic>("dbo.spMeasurement_GetWithData", new
		{
			Id = id,
		});
		var r = results.FirstOrDefault();

		var scalesInDB = System.Text.Json.JsonSerializer.Deserialize<List<StorableScale>>(r.SerializedData);
		r.Scales.Clear();

		foreach (var sca in scalesInDB ?? new List<StorableScale>())
		{
			var GeneratedScale = ScalesService.GenerateNewScale(sca.ScaleID);
			if (GeneratedScale is not null)
			{
				if (!sca.IsMeasured)
				{
					//GeneratedScale.LoadValuesFromDB(sca.SimplifiedResults);
					GeneratedScale.GenerateScore();
				}
				else
				{

				}

				r.Scales.Add(GeneratedScale);
			}
		}
		return r;
	}

	public async Task<Session> LoadSession(SelectedItems Current)
	{
		Guid id = Current.SelectedSession.Id;
		var results = await db.LoadData<Session, dynamic>("dbo.spMeasurement_GetWithData", new
		{
			Id = id,
		});
		var r = results.FirstOrDefault();
		
		var scalesInDB = System.Text.Json.JsonSerializer.Deserialize<List<StorableScale>>(r.SerializedData);
		Current.SelectedSession.Scales.Clear();

		foreach(var sca in scalesInDB??new List<StorableScale>())
		{
			var GeneratedScale = ScalesService.GenerateNewScale(sca.ScaleID);
			if(GeneratedScale is not null)
			{
				if (sca.IsMeasured)
				{
					GeneratedScale.LoadValuesFromDB(sca.SimplifiedResults);
					GeneratedScale.GenerateScore();
				}
				else
				{
					
				}

				Current.SelectedSession.Scales.Add(GeneratedScale);
			}
		}

		Current.SelectedSession.IsFullyLoaded = true;
		/*
		var s = Session.FromJson(r.SerializedData);
		foreach (var x in s.Scales)
		{
			if (x != null && x.IsMeasured)
				x.GenerateScore();
		}

		s.IsFullyLoaded = true;
		*/

		return Current.SelectedSession;
	}

	public async Task LoadAllSessionDetailsInTherapy(SelectedItems current)
	{
		try
		{
			var t = current.SelectedTherapy ?? new Therapy();

			List<Session> before = new();

			foreach (var s in t.Sessions)
				before.Add(s);

			t.Sessions.Clear();

			foreach (var s in before)
			{
				if (!s.IsFullyLoaded)
				{
					SelectedItems temp = new SelectedItems();
					temp.SelectedTherapy = current.SelectedTherapy;
					temp.SelectedPatient = current.SelectedPatient;
					temp.SelectedSession = s;
					t.Sessions.Add(await LoadSession(temp));
				}
				else
					t.Sessions.Add(s);
			}
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	public async Task DeleteSession(Session session)
	{
		try
		{
			await db.SaveData("dbo.spMeasurement_Delete", new { Id = session.Id });
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	public async Task UpadePatientLabelInAllSessions(Patient p, string newPatientLabel)
	{
		foreach(var label in p.TherapyLabels)
		{
			var summaries = await sGetAllMeasurementsSummariesOfTherapy(label);
			var newTherapy = new Therapy { KeyCode = PatientLabelTools.GetTherapyKeyCode(label)};

			foreach(var summary in summaries)
			{
				SelectedItems temp = new();
				temp.SelectedPatient = p;
				temp.SelectedTherapy = newTherapy;
				temp.SelectedSession = summary;

				var session = await UpdateSessionInTherapyWithDetailsFromDB(temp);
				newTherapy.TherapyLabel = PatientLabelTools.GetTherapyLabel(session.SessionID);
				session.CreateSessionLabel(newPatientLabel, newTherapy);
				newTherapy.Sessions.Add(session);
				session.GenerateTags();


				await DeleteSession(session);
				await StoreSession(new SelectedItems { SelectedPatient = p, SelectedTherapy = newTherapy, SelectedSession = session});
			}

		}
	}

	#endregion


}
