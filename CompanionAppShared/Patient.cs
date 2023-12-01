using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanionAppShared;

public class Patient
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[Required]
	public string PatientLabel { get; set; } = string.Empty;
	public AvailbleSex Sex { get; set; } = AvailbleSex.Male;
	public DateTime? BirthDate { get; set; }	= DateTime.Now;
	public DateTime? DateOfDiagnosis { get; set; }	= DateTime.Now;
	public DateTime? StartingDateForStudy { get; set; }	= DateTime.Now;
	public string Diagnosis { get; set; } = string.Empty;
	public bool AlreadyInRehabTherapy { get; set; } = false;
	public string RehabTherapyDetails { get; set; } = string.Empty;
	public string MedicationInUse { get; set; } = string.Empty;
	public string Notes { get; set;} = string.Empty;


	public List<Therapy> Therapies { get; set; } = new();

	[JsonIgnore]
	public bool IsFullyLoadedFromDB { get; set; } = false;






	public List<Measurement>? Measurements { get; set; } = null;
	private int _numberOfMeasurements = 0;
	public int NumberOfMeasurements
	{
		get 
		{ 
			if (Measurements is null) return _numberOfMeasurements;
			else return Measurements.Count;
		}
		set { _numberOfMeasurements = value; }
	}

	private DateTime? _lastMeasurement;
	public DateTime? LastMeasurement
	{
		set { _lastMeasurement = value; }
		get 
		{
			if (Measurements is null)
			{
				if(_lastMeasurement is not null) return _lastMeasurement;
				else return null;
			}

			return Measurements.OrderBy(x=>x.Date).First().Date; 
		}
	}

	public string SerializedData { get; set; } = string.Empty;

	public string Serialize() => JsonSerializer.Serialize(this);

	public static Patient FromJson(string json) => JsonSerializer.Deserialize<Patient>(json) ?? new Patient();

	public Patient Clone()
	{
		var str = JsonSerializer.Serialize(this);
		var p = JsonSerializer.Deserialize<Patient>(str);
		for(int t = 0; t < p.Therapies.Count; ++t)
		{
			for(int ic =0; ic < this.Therapies[t].InclusionCriteria.Count; ++ic)
			{
				p.Therapies[t].InclusionCriteria[ic].IsSet = this.Therapies[t].InclusionCriteria[ic].IsSet;
			}
			for (int ec = 0; ec < this.Therapies[t].ExclusionCriteria.Count; ++ec)
			{
				p.Therapies[t].ExclusionCriteria[ec].IsSet = this.Therapies[t].ExclusionCriteria[ec].IsSet;
			}
		}

		return p;
	}
}