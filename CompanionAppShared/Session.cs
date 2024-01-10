using System;
using System.Collections.Generic;
using System.Linq;
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
	public string PatientID { get; set; } = "PatientID not set";
	public string TherapyID { get; set; } = "Therapy ID not set";
	public string Tag { get; set; } = "Unknown";
	public string AccuracyTag { get; set; } = "Unknown";
	public DateTime Date { get; set; }	= DateTime.Now;
	public List<IScale> Scales { get; set; } = new();
	public string SerializedData { get; set; } = string.Empty;
	public SessionKinds SessionKind { get; set; } = SessionKinds.Intermediate;

	public void Init(Therapy therapy, ScalesService SService)
	{
		Scales.Clear();
		foreach(var scale in therapy.Scales)
		{
			Scales.Add(SService.GenerateScale(scale));
		}
	}

	public void Serialize() => SerializedData = JsonSerializer.Serialize(this);

	public Session Clone()
	{
		var str = JsonSerializer.Serialize(this);
		return JsonSerializer.Deserialize<Session>(str);
	}
}
