using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared.Scales.Scales;

public class ScaleItem
{
	public virtual string StringValue { get; set; } = string.Empty;
}

public class IntItem : ScaleItem
{
	int Value;
	public override string StringValue
	{
		get { return Value.ToString(); }
		set {
			var didWork = int.TryParse(value, out int i);
			if(didWork) Value = i;
		}
	}
}

public class StringItem : ScaleItem
{
	string _value = string.Empty;
	public override string StringValue => _value;
}

public class TimeSpanItem : ScaleItem
{
	TimeSpan Value = new TimeSpan();
	public override string StringValue
	{
		get {
			string s = "";
			if(Value.Minutes > 0) s += Value.Minutes+"m";
			s += " "+Value.Seconds+"s";
			return s;
		}
	}
}
