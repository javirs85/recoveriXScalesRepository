using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class Measurement
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public Guid PatientID { get; set; } = Guid.NewGuid();
	public Guid ScaleID { get; set; } = Guid.NewGuid();
	public DateTime Date { get; set; }	= DateTime.Now;
	[JsonIgnore]
	public ScaleBase Scale { get; set; } = new();
	public string SerializedData { get; set; } = string.Empty;
}
