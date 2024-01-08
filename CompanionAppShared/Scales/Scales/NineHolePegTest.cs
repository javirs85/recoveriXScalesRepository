

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class NineHolePegTest : ScaleBase
{
    public NineHolePegTest()
    {
		Id = ScalesIDs.NineHPT;
		Name = "Nine hole peg test";
		ShortName = "9HPT";
		AreaOfStudy = "Dexterity";

		ScoreNormalized = 0;
	}

	public TimeSpanItem TimePareticHand { get; set; } = new TimeSpanItem { Label = "Paretic hand:"};
	public TimeSpanItem TimeHealthyHand { get; set; } = new TimeSpanItem { Label = "Healthy hand:"};

	public StringItem StringItem { get; set; } = new StringItem { Label="Test string", StringValue = "Default value" };
	public IntItem IntItem { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public FloatItem FloatItem { get; set; } = new FloatItem { Label = "Test float", StringValue = "3,14" };
	public OptionsItem OptionsItem { get; set; } = new OptionsItem
	{
		Options = new List<string> { "option 1", "option 2", "option 3" },
		Label = "Select your option:"
	};


	protected override bool GenerateScoreInternal()
	{
		Details.Clear();
		Details.Add($"Paretic hand: {TimePareticHand.StringValue}");
		Details.Add($"healthy hand: {TimeHealthyHand.StringValue}");
		var floatscore = (TimeHealthyHand.Value.TotalSeconds / TimePareticHand.Value.TotalSeconds) * 100;
		ScoreNormalized = (int)Math.Round(floatscore);

		if(ScoreNormalized < 0) ScoreNormalized = 0;
		if(ScoreNormalized > 100) ScoreNormalized = 100;	
 
		return true;
	}

	protected override void ResetInternal()
	{
		TimePareticHand = new TimeSpanItem { Label = "Paretic hand:" };
		TimeHealthyHand = new TimeSpanItem { Label = "Healthy hand:" };
		StringItem = new StringItem { Label = "Test string", StringValue = "Default value" };
		IntItem = new IntItem { Label = "Test int", StringValue = "12" };
		FloatItem = new FloatItem { Label = "Test float", StringValue = "3,14" };
		OptionsItem = new OptionsItem
		{
			Options = new List<string> { "option 1", "option 2", "option 3" },
			Label = "Select your option:"
		};
	}
}
