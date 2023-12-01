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

	private readonly ISQLDataAccess db;

	public DataBase(ISQLDataAccess db)
	{
		this.db = db;
	}

	private bool AlreadyInitialized = false;

	public void Init()
	{
		if (AlreadyInitialized) return;

		AlreadyInitialized = true;
		Task.Run(async () => await LoadListOfPatients());
	}

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
	/// Gets ALL the serialized data for a given patient's ID and deserializes it into a fully fledged patient.
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<Patient?> GetPatient(Guid id)
	{
		var results = await db.LoadData<Patient, dynamic>("dbo.spPatient_Get", new { Id = id });
		var r = results.FirstOrDefault();
		var p = Patient.FromJson(r.SerializedData);
		p.IsFullyLoadedFromDB = true;
		return p;
	}

	public async Task InsertPatient(Patient patient)
	{
		var serialized = patient.Serialize();
		await db.SaveData("dbo.spPatient_Insert",
		new
		{
			patient.Id,
			patient.PatientLabel,
			patient.NumberOfMeasurements,
			patient.LastMeasurement,
			SerializedData = serialized
		});
	}

	public Task UpdatePatient(Patient patient) => db.SaveData("dbo.spPatient_Update", new { 
		Id = patient.Id,
		Label = patient.PatientLabel,
		NumberOfMeasurements = patient.NumberOfMeasurements,
		LastMeasurement = patient.LastMeasurement,
		SerializedData = patient.Serialize()
	});
	public Task DeletePatient(Guid id) => db.SaveData("dbo.spPatient_Delete", new { Id = id });


	public Task<IEnumerable<Measurement>> GetAllMeasurementsOfPatient(Guid patientID) =>
		db.LoadData<Measurement, dynamic>("dbo.spMeasurement_GetAllFromPatient", new { PatientID = patientID });

	public async Task InsertMeasurement(Measurement measurement)
	{
		await db.SaveData("spMeasurement_Insert",
		new
		{
			measurement.Id,
			measurement.PatientID,
			measurement.Date,
			measurement.ScaleID,
			measurement.SerializedData
		});
	}
}
