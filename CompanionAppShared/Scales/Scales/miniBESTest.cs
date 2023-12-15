

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class miniBESTest : ScaleBase
{
    public miniBESTest()
    {
		Id = ScalesIDs.miniBESTest;
		Name = "Mini Balance Evaluation Test";
		ShortName = "mini BESTest";
		AreaOfStudy = "Balance";
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
