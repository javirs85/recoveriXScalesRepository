

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class UPDRSI : ScaleBase
{
    public UPDRSI()
    {
		Id = ScalesIDs.UPDRSI;
		Name = "Unified Parkinson's Disease Rating Scale - Section I";
		ShortName = "UPDRS-I";
		AreaOfStudy = "Mentation, Behavior Mood";
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
