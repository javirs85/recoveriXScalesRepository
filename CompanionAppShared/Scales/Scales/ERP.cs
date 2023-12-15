

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class ERP : ScaleBase
{
    public ERP()
    {
		Id = ScalesIDs.ERP;
		Name = "Evoked Related Potentials";
		ShortName = "ERP";
		AreaOfStudy = "Brain responses";
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
