

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class MoCA : ScaleBase
{
    public MoCA()
    {
		Items = new List<ScaleItem>
		{ 
			new IntItem { JsonCode = "Visuospatial", Label = "Visuospatial/Executive (max. 5)", StringValue = "_", MinValue = 0, MaxValue = 5 },
			new IntItem { JsonCode = "Naming", Label = "Naming (max. 3)", StringValue = "_", MinValue = 0, MaxValue = 3 },
			new IntItem { JsonCode = "Attention", Label = "Attention (max. 6)", StringValue = "_", MinValue = 0, MaxValue = 6 },
			new IntItem { JsonCode = "Language", Label = "Language (max. 3)", StringValue = "_", MinValue = 0, MaxValue = 3 },
			new IntItem { JsonCode = "Abstraction", Label = "Abstraction (max. 2)", StringValue = "_", MinValue = 0, MaxValue = 2 },
			new IntItem { JsonCode = "Delayed", Label = "Delayed recall (max. 5)", StringValue = "_", MinValue = 0, MaxValue = 5 },
			new IntItem { JsonCode = "Orientation", Label = "Orientation (max. 6)", StringValue = "_", MinValue = 0, MaxValue = 6 }
		};
    }

	public override void Init()
	{
		Id = ScalesIDs.MoCA;
		Name = "Montreal cognitive assessment";
		ShortName = "MoCA";
		AreaOfStudy = "Cognitive status";
		AutoScoreExplanation = "With 0 points the score reaches 0%. The maximum of points leads to 100% score.";
	}

	public override void FixItemsInternal()
	{
	}


	protected override void GenerateScoreInternal()
	{
		ScoreRaw = 0;
		foreach(var i in Items)
		{
			ScoreRaw += (i as IntItem).Value;
		}
		ScoreNormalized = (int)LinearInterpolation(0, 30, ScoreRaw);
	}

	protected override void GenerateDetails()
	{
		Details.Clear();
		string s = "";

		foreach(var i in Items)
		{
			s += " "+(i.StringValue);
		}	

		Details.Add(s);
	}

	protected override void ResetInternal()
	{
	}

}
