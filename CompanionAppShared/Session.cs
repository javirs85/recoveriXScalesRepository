using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class Session
{
	public DateTime Date { get; set; } = DateTime.Now;
	public List<IScale> RanScales { get; set; } = new();
	public SessionKinds SessionKind { get; set; } = SessionKinds.Intermediate;
}
