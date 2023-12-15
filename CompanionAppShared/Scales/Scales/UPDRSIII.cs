

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class UPDRSIII : ScaleBase
{
    public UPDRSIII()
    {
		Id = ScalesIDs.UPDRSIII;
		Name = "Unified Parkinson's Disease Rating Scale - Section III";
		ShortName = "UPDRSIII";
		AreaOfStudy = "Motor examination";
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
