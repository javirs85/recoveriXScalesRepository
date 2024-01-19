

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TUG : ScaleBase
{
	//Check GenerateScoreInternal for details

    public TUG()
    {
		Id = ScalesIDs.TUG;
		Name = "Timed Up & Go";
		ShortName = "TUG";
		AreaOfStudy = "Balance and gait";

		DetailsHeaders.Add("Time (m)");
    }

	public TimeSpanItem TimePareticHand { get; set; } = new TimeSpanItem { Label = "Time to stand up and go" };

	protected override void GenerateScoreInternal()
	{
		//This score assumes Average time up 45. Mas Time up 135s
		//To change those values please update the ScoreNormalized function.

		ScoreRaw = (int)Math.Ceiling(TimePareticHand.Value.TotalSeconds);
		if (ScoreRaw < 35) ScoreNormalized = 0;
		else if (ScoreRaw > 135) ScoreNormalized = 100;
		else
			ScoreNormalized = ((-10 / 9) * ScoreRaw) + 150;

	}

	protected override void ResetInternal()
	{
		TimePareticHand = new TimeSpanItem { Label = "Time to stand up and go" };
	}

	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(TimePareticHand.StringValue);
	}
}
