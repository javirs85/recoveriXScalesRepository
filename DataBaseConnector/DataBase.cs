using CompanionAppShared;
using CompanionAppShared.Scales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	public string errorMessage = string.Empty;


	public DataBase(ISQLDataAccess _db)
	{
		db = _db;
		db.OnNewError += HandleError;
	}

	private void HandleError(object? sender, Exception e)
	{
		IsLoading = false;
		HasError = true;
		errorMessage = e.Message;
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
		return p;
	}

	public async Task<bool> CheckIfNameIsAlreadyTaken(Patient p)
	{
		ErrorOccurred?.Invoke(this, new Exception("CheckIfNameIsAlreadyTaken is not yet implemented, defaulting to false"));
		return false;
	}

	public async Task InsertPatient(Patient patient)
	{
		var serialized = patient.Serialize();
		try
		{
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

	public async Task UpdatePatient(Patient patient)
	{
		try
		{
			await db.SaveData("dbo.spPatient_Update", new
			{
				Id = patient.Id,
				Label = patient.PatientLabel,
				NumberOfMeasurementsInLastTherapy = patient.NumberOfSessions,
				LastMeasurementInLastTherapy = patient.LastSession,
				SerializedData = patient.Serialize()
			});
		}
		catch(Exception e)
		{
			ErrorOccurred?.Invoke(this, e);	
		}
	}
	public Task DeletePatient(Guid id) => db.SaveData("dbo.spPatient_Delete", new { Id = id });

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
	public async Task InsertOrUpdateMeasurement(SelectedItems current, IScale NewScale)
	{
		current.SelectedSession.Scales.Remove(current.SelectedScale);
		current.SelectedSession.Scales.Add(NewScale);
		current.SelectedScale = NewScale;

		try
		{
			current.SelectedSession.Serialize();
			await db.SaveData("spMeasurement_InsertOrUpdate",
			new
			{
				current.SelectedSession.Id ,
				current.SelectedSession.PatientID,
				current.SelectedSession.Date,
				current.SelectedSession.TherapyID,
				current.SelectedSession.Tag,
				current.SelectedSession.AccuracyTag,
				current.SelectedSession.SerializedData
			});
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}

	public async Task<Session> LoadAllDetailsOfSession(Session session)
	{
		try
		{
			var results = await db.LoadData<Session, dynamic>("dbo.spMeasurement_GetWithData", new { 
				Id = session.Id,
			});
			var r = results.FirstOrDefault();
			var s = Session.FromJson(r.SerializedData);
			foreach(var x in s.Scales)
			{
				if(x != null && x.IsMeasured) 
					x.GenerateScore(); 
			}
			return s;
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
			return session;
		}
	}
	#endregion


}
