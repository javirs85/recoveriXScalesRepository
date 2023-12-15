

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class MFIS : ScaleBase
{
    public MFIS()
    {
		Id = ScalesIDs.MFIS;
		Name = "Modified Fatigue Impact Scale";
		ShortName = "MFIS";
		AreaOfStudy = "Fatigue";
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
