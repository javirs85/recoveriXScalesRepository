using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared.Scales;

public class ScalesService
{
	public List<IScale> Scales { get; set; } = new List<IScale>
	{
		new NineHolePegTest(),

	};
}
