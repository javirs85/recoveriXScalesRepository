

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class PDQ39 : ScaleBase
{
    public PDQ39()
    {
		Id = ScalesIDs.PDQ39;
		Name = "Parkinson's Disease Questionnaire";
		ShortName = "PDQ39";
		AreaOfStudy = "Impact of the disease";
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
