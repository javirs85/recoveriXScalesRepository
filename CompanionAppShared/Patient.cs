using CompanionAppShared.Therapies;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanionAppShared;

public class Patient
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public Gyms Gym { get; set; }
	public string GymCode => Gym.ToString();
	private string _patientLabel = string.Empty;
	[Required]
	public string PatientLabel {
		get
		{
			return _patientLabel;
		}
		set
		{
			if (_patientLabel != value) { 
				_patientLabel = value;

				//Upadte all therapies with the new label
				var ExistingTherapies = new List<Therapy>();
				foreach (var t in Therapies)
					ExistingTherapies.Add(t);

				if(Therapies.Count > 0)
				{
					Therapies.Clear();
					TherapyLabels.Clear();

					foreach (var t in ExistingTherapies)
						AddTherapy(t);

					//Update all sessions in all therapies with new label

					foreach (var t in Therapies)
					{
						foreach (var s in t.Sessions)
						{
							s.CreateSessionLabel(PatientLabel, t); ;
						}
					}
				}
				
			}
		}
	} 
	public AvailbleSex Sex { get; set; } = AvailbleSex.Male;
	public DateTime? BirthDate { get; set; }	= DateTime.Now;
	public DateTime? DateOfDiagnosis { get; set; }	= DateTime.Now;
	public DateTime? StartingDateForStudy { get; set; }	= DateTime.Now;
	public string Diagnosis { get; set; } = string.Empty;
	public bool AlreadyInRehabTherapy { get; set; } = false;
	public string RehabTherapyDetails { get; set; } = string.Empty;
	public string MedicationInUse { get; set; } = string.Empty;
	public string Notes { get; set;} = string.Empty;


	[JsonIgnore]
	private List<Therapy> Therapies { get; set; } = new();

	public List<string> TherapyLabels { get; set; } = new();


	public void AddTherapy(Therapy therapy)
	{
		string name = PatientLabel + "." + therapy.KeyCode;

		int count = TherapyLabels.Count(x => PatientLabelTools.GetTherapyKeyCode(x) == therapy.KeyCode);
		name += "." + count.ToString();

		therapy.TherapyLabel = name;
		Therapies.Add(therapy);
		TherapyLabels.Add(name);
	}

	public Therapy GetParkinsonTherapy() {
		var t = Therapies.Find(x => x.KeyCode == "PS");
		return t; 
	}

	public bool HasTherapies => Therapies.Count > 0 || TherapyLabels.Count > 0;
	public Therapy GetTherapy(string therapyID) => Therapies.Find(x => x.TherapyLabel == therapyID);

	[JsonIgnore]
	public bool IsFullyLoadedFromDB { get; set; } = false;

	public string NumberOfMeasurementsInLastTherapy { get; set; } = "-";

	public string NumberOfSessions
	{
		get
		{
			if (Therapies is null || Therapies.Count == 0 || Therapies[0].Sessions is null || Therapies[0].Sessions.Count == 0) return NumberOfMeasurementsInLastTherapy;
			else return Therapies.OrderByDescending(t => t.Sessions.Max(s => s.MeasurementDate)).FirstOrDefault()?.Sessions.Count.ToString() ?? "0";
		}
	}

	public string LastMeasurementInLastTherapy { get; set; } = "-";

	private DateTime? _lastSession;
	public DateTime? LastSession
	{
		get 
		{
			if (Therapies is null || Therapies.Count == 0 || Therapies[0].Sessions is null || Therapies[0].Sessions.Count == 0) return null;
			else return Therapies.SelectMany(t => t.Sessions).Max(s => s.MeasurementDate);
		}
	}

	public string SerializedData { get; set; } = string.Empty;

	public string Serialize() => JsonSerializer.Serialize(this);

	public static Patient FromJson(string json) => JsonSerializer.Deserialize<Patient>(json) ?? new Patient();

	public Patient Clone()
	{
		var str = JsonSerializer.Serialize(this);
		var p = JsonSerializer.Deserialize<Patient>(str);
		for(int t = 0; t < this.Therapies.Count; ++t)
		{
			Therapy newTherapy = new Therapy();
			newTherapy.CopyDataFrom(this.Therapies[t]);
			p.Therapies.Add(newTherapy);
		}

		return p;
	}

	public void ReconstructTherapyWithSeasons(IEnumerable<Session> sessions, string v)
	{
		var t = new ParkinsonStudy();
		t.TherapyLabel = v;
		t.Sessions = sessions.ToList();
		foreach (var c in t.ExclusionCriteria) c.Value = false;
		foreach (var c in t.InclusionCriteria) c.Value = true;
		Therapies.Add(t);
	}
}