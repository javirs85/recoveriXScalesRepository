

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TUG : ScaleBase
{
    public TUG()
    {
		Id = ScalesIDs.TUG;
		Name = "Timed Up & Go";
		ShortName = "TUG";
		AreaOfStudy = "Balance and gait";
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
