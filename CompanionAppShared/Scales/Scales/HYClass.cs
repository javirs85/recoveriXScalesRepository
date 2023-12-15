

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class HYClass : ScaleBase
{
    public HYClass()
    {
		Id = ScalesIDs.HYClass;
		Name = "UPDRS - V (Hoehn and Yahr Scale)";
		ShortName = "HYClass";
		AreaOfStudy = "PD disease classification";
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
