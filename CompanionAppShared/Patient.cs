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

	public bool HasTherapies => Therapies.Count > 0;
	public Therapy GetTherapy(string therapyID) => Therapies.Find(x => x.TherapyLabel == therapyID);

	[JsonIgnore]
	public bool IsFullyLoadedFromDB { get; set; } = false;






	public List<Session>? Sessions { get; set; } = null;
	private int _numberOfSessions = 0;
	public int NumberOfSessions
	{
		get 
		{ 
			if (Sessions is null) return _numberOfSessions;
			else return Sessions.Count;
		}
		set { _numberOfSessions = value; }
	}

	private DateTime? _lastSession;
	public DateTime? LastSession
	{
		set { _lastSession = value; }
		get 
		{
			if (Sessions is null)
			{
				if(_lastSession is not null) return _lastSession;
				else return null;
			}

			return Sessions.OrderBy(x=>x.Date).First().Date; 
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