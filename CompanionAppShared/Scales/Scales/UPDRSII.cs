

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class UPDRSII : ScaleBase
{
    public UPDRSII()
    {
		Id = ScalesIDs.UPDRSII;
		Name = "Unified Parkinson's Disease Rating Scale - Section II";
		ShortName = "UPDRS-II";
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
