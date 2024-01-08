using CompanionAppShared;
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
<<<<<<< HEAD
	public event EventHandler<Exception> ErrorOccurred;

	private readonly ISQLDataAccess db;

	#region init

	public DataBase(ISQLDataAccess db)
=======
	public bool HasError = false;
	public string errorMessage = string.Empty;

	private readonly ISQLDataAccess db;

	public DataBase(ISQLDataAccess _db)
>>>>>>> b6ba10a4a19e560fbdd16c842b54e789c89c5bec
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
	/// gets a sumary of all the patients without the SerializedData field. 
	/// If you want all the info for a given patient you need to call GetPatient afterwards
	/// </summary>
	/// <returns></returns>
	public Task<IEnumerable<Patient>> GetPatients() => db.LoadData<Patient, dynamic>("dbo.spPatient_GetAll", new { });

	/// <summary>
	/// Gets ALL the serialized data for a given patient's TherapyLabel and deserializes it into a fully fledged patient.
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<Patient?> GetPatient(Guid id)
	{
		var results = await db.LoadData<Patient, dynamic>("dbo.spPatient_Get", new { Id = id });
		var r = results.FirstOrDefault();
		var p = Patient.FromJson(r.SerializedData);
		var sessions = await GetAllMeasurementsOfTherapy(p.TherapyLabels[0]);
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
	public Task<IEnumerable<Session>> GetAllMeasurementsOfTherapy(string therapyID) =>
		db.LoadData<Session, dynamic>("dbo.spMeasurement_GetAllSessionHighlightsFromTherapy", new { TherapyID = therapyID });

	public async Task InsertMeasurement(Session measurement)
	{
		try
		{
			measurement.Serialize();
			await db.SaveData("spMeasurement_Insert",
			new
			{
				measurement.Id ,
				measurement.PatientID,
				measurement.Date,
				measurement.TherapyID,
				measurement.Tag,
				measurement.AccuracyTag,
				measurement.SerializedData
			});
		}
		catch (Exception e)
		{
			ErrorOccurred?.Invoke(this, e);
		}
	}
	#endregion


}
