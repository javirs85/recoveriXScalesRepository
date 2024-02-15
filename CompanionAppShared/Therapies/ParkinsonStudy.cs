using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanionAppShared.Therapies;

public class ParkinsonStudy : Therapy
{
    public ParkinsonStudy()
    {
        Name = "Parkinson study";
        KeyCode = "PS";

        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Other neurological diseases" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Severe depression" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Uncontrolled diabetes" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Concomitant severe neurologic, cardiopulmonary, or\r\northopedic disorders" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Debilitating conditions or vision impairment that would\r\nimpede full participation in the study" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Unpredictable motor fluctuations" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Pregnant" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Active or passive implanted medical devices such as\r\npacemakers which do not allow the use of FES" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Implanted metallic fragments in the upper and lower\r\nextremities which can limit the use of FES" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Under the influence of\r\nanesthesia or similar medication" });
        ExclusionCriteria.Add(new InclusionExclusionCriteria { Title = "With fractures or lesions in the upper and lower extremities" });

        InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Diagnosis of PD" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "HY stage between 1 to 3" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "MMSE > 24" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Age between 40 and 80 years old" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Ability to walk independently" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "stable medication usage" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Stable neurological condition" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Able to sign the informed consent" });
		InclusionCriteria.Add(new InclusionExclusionCriteria { Title = "Able to follow the study protocol" });

        Scales = new List<ScalesIDs> {
            ScalesIDs.UPDRSI,
            ScalesIDs.UPDRSII,
            ScalesIDs.UPDRSIII,
            ScalesIDs.UPDRSIV,
            ScalesIDs.HYClass,
            ScalesIDs.SEADL,
            ScalesIDs.PDQ39,
            ScalesIDs.MFIS,
            ScalesIDs.NineHPT,
            ScalesIDs.TUG,
            ScalesIDs.TENMWT,
            ScalesIDs.FOGQ,
            ScalesIDs.ERP,
            ScalesIDs.ATA,
            ScalesIDs.MoCA
        };

    }
}
