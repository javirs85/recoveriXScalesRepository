

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class SEADL : ScaleBase
{
    public SEADL()
    {
		Id = ScalesIDs.SEADL;
		Name = "UPDRS - VI (Schwab and England ADL Scale)";
		ShortName = "SEADL";
		AreaOfStudy = "Activities in Daily Living";
    }

    public int TimeInSecondsPareticHand { get; set; }
	public int TimeInSecondsHealthyHand { get; set; }


	public TimeOnly TimeParetic => TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(TimeInSecondsPareticHand));
	public TimeOnly TimeHealthy => TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(TimeInSecondsHealthyHand));
	public string TimePareticUI => TimeParetic.ToShortTimeString();
	public string TimeHealthyUI => TimeHealthy.ToShortTimeString();



	public override void GenerateScore()
	{
	}
}
