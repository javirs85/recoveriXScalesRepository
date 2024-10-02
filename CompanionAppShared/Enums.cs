using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared;

public enum AvailbleSex { Male, Female};
public enum ScalesIDs {
	NotSet,
	NineHPT, 
	UPDRSI,
	UPDRSII,
	UPDRSIV,
	HYClass,
	UPDRSIII,
	PDQ39,
	MFIS,
	TUG,
	TENMWT_FV,
	TENMWT_SSV,
	miniBESTest,
	FOGQ,
	ERP,
	ATA,
	SEADL,
	BnBT,
	MoCA
}

public enum  Gyms { SCH, BCN }

public enum SessionKinds { Pre, Intermediate, Post}