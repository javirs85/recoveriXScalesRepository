using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CompanionAppShared.Scales;

namespace CompanionAppShared;

public class Session
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string PatientID => PatientLabelTools.GetPatientLabel(SessionID);
	public string TherapyID => PatientLabelTools.GetTherapyLabel(SessionID);
	public string SessionID { get; set; } = "Session ID not "; 
	public string Tag { get; set; } = "Unknown";
	public string AccuracyTag { get; set; } = "Unknown";
	public DateTime MeasurementDate { get; set; }	= DateTime.Now;
	public List<IScale> Scales { get; set; } = new();
	public string SerializedData { get; set; } = string.Empty;
	public SessionKinds SessionKind { get; set; } = SessionKinds.Intermediate;

	[JsonIgnore]
	public bool IsFullyLoaded { get; set; } = false;

	public void Init(Therapy therapy, ScalesService SService)
	{
		Scales.Clear();
		foreach(var scale in therapy.Scales)
		{
			Scales.Add(SService.GenerateScale(scale));
		}
	}

	public void CreateSessionLabel(string patientLabel, Therapy th)
	{
		SessionID = PatientLabelTools.FormLabel(
			patientLabel,
			th.KeyCode,
			PatientLabelTools.GetTherapyRepetitionNumber(th.TherapyLabel),
			th.Sessions.Count
			);
	}


	public static Session FromJson(string json)
	{
		var item = JsonSerializer.Deserialize<Session>(json) ?? new Session();
		foreach (var scale in item.Scales)
			scale.FixEvents();
		return item;	
	}

	public Session Clone()
	{
		var str = JsonSerializer.Serialize(this);
		return JsonSerializer.Deserialize<Session>(str);
	}

	public void GenerateTags()
	{
		var tags = from scale in Scales
			   where scale.IsMeasured
			   select scale.ShortName;

		Tag = string.Join(", ", tags.ToArray());
		int num = Scales.Count;
		int finished = Scales.Count(x => x.IsMeasured == true);
		AccuracyTag = (finished * 100 / num).ToString();
	}
}
