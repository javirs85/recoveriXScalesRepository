

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;

public class FOGQ : ScaleBase
{
    public FOGQ()
    {
		Id = ScalesIDs.FOGQ;
		Name = "Freezing Of Gait Questionnaire";
		ShortName = "FOGQ";
		AreaOfStudy = "Freezing of gait";
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
