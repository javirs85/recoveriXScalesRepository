using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared.Scales;

public class ScalesService
{
	//When registering a new Scale here, don't forget to add the JsonDerive at the ScaleBase
	public IScale GenerateScale(ScalesIDs scalesIDs)
	{
		return scalesIDs switch
		{
			ScalesIDs.ATA => new ATA(),
			ScalesIDs.ERP => new ERP(),
			ScalesIDs.FOGQ => new FOGQ(),
			ScalesIDs.HYClass => new HYClass(),
			ScalesIDs.MFIS => new MFIS(),
			ScalesIDs.miniBESTest => new miniBESTest(),
			ScalesIDs.NineHPT => new NineHolePegTest(),
			ScalesIDs.PDQ39 => new PDQ39(),
			ScalesIDs.SEADL => new SEADL(),
			ScalesIDs.TENMWT => new TENMWT(),
			ScalesIDs.TUG => new TUG(),
			ScalesIDs.UPDRSI => new UPDRSI(),
			ScalesIDs.UPDRSII => new UPDRSII(),
			ScalesIDs.UPDRSIII => new UPDRSIII(),
			ScalesIDs.UPDRSIV => new UPDRSIV(),

			_ => throw new Exception($"The scale '{scalesIDs}' has not been registered at the ScalesService, don't forget to add the JsonDerived at ScaleBase")
		} ;
	}
}
