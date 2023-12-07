using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared.Scales;

public abstract class ScaleItem
{
	public enum ItemTypes { NotSet, Time, String, Int};
	public string Title { get; set; }= string.Empty;
	public ItemTypes ItemType { get; set; } = ItemTypes.NotSet;
	public abstract string ToString();
}

public class ScaleItemInt : ScaleItem
{
	public int Value { get; set; }
	public override string ToString()
	{
		return Value.ToString();
	}
}

public class ScaleItemTime : ScaleItem
{
	public int Seconds { get; set; }
	public override string ToString()
	{
		var ts = TimeSpan.FromSeconds(Seconds);
		return ts.ToString();
	}
}
