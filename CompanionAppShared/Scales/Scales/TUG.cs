

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TUG : ScaleBase
{
	//Check GenerateScoreInternal for details

    public TUG()
    {
		
    }

	public override void Init()
	{
		Id = ScalesIDs.TUG;
		Name = "Timed Up & Go";
		ShortName = "TUG";
		AreaOfStudy = "Balance and gait";

		DetailsHeaders.Add("Time (m)");

		Items = new List<ScaleItem>
		{
			TimedExecution
		};
	}

	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(TimedExecution);
	}


	public TimeSpanItem TimedExecution { get; set; } = new TimeSpanItem { JsonCode = "R1", Label = "Time to stand up and go" };

	protected override void GenerateScoreInternal()
	{
		//This score assumes Average time up 45. Mas Time up 135s
		//To change those values please update the ScoreNormalized function.



		ScoreRaw = (int)Math.Ceiling(TimedExecution.Value.TotalSeconds);

		var externalized = ScaleBase.LinearInterpolation(135, 45, ScoreRaw);

		if (ScoreRaw < 35) ScoreNormalized = 0;
		else if (ScoreRaw > 135) ScoreNormalized = 100;
		else
			ScoreNormalized = ((-10 / 9) * ScoreRaw) + 150;

		//TODO: Marc provides refrence values
		//9.0s pacients entre 60 i 69 anys
		//10.2 70-79
		//12.7 80-99

	}

	protected override void ResetInternal()
	{
		TimedExecution = new TimeSpanItem { Label = "Time to stand up and go" };
	}

	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(TimedExecution.StringValue);
	}
}
