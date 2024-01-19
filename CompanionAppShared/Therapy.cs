using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public class Therapy
{
	public string KeyCode { get; set; } = "KNS"; //Key not set
	public string TherapyLabel { get; set; } = "GYM_PID_KeyKode_N";
	public string Name { get; set; } = string.Empty;
	public List<InclusionExclusionCriteria> ExclusionCriteria { get; set; } = new();
	public List<InclusionExclusionCriteria> InclusionCriteria { get; set; } = new();
	public bool AreAllCriteriaMeet
	{
		get
		{
			if (ExclusionCriteria.Find(x =>!x.IsSet || x.IsSet && x.IsTrue) != null) return false;
			if(InclusionCriteria.Find(x => !x.IsSet || x.IsSet && x.IsFalse) != null) return false;
			return true;
		}
	}

	public List<ScalesIDs> Scales = new(); 
	public List<Session> Sessions = new();

	public void CopyDataFrom(Therapy t)
	{
		KeyCode = t.KeyCode;
		TherapyLabel = t.TherapyLabel;
		Name = t.Name;
		foreach(var c in t.ExclusionCriteria) ExclusionCriteria.Add(c);
		foreach(var c in t.InclusionCriteria) InclusionCriteria.Add(c);
	}
}

public class InclusionExclusionCriteria
{
	public string Title { get; set; } = string.Empty;
	public bool IsSet { get; set; } = false;
	private bool _value = false;
	public bool Value
	{
		get { return _value; }
		set {  
			IsSet = true;
			_value = value; 
		}
	}

	public bool IsFalse => IsSet && _value == false;
	public bool IsTrue => IsSet && _value == true;
}
