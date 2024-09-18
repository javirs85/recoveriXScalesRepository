

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class SEADL : ScaleBase
{
    public SEADL()
    {
		
    }
	public override void Init()
	{
		Id = ScalesIDs.SEADL;
		Name = "UPDRS - VI (Schwab and England ADL Scale)";
		ShortName = "SEADL";
		AreaOfStudy = "Activities in Daily Living";
		AutoScoreExplanation = "With 0 points the score reaches 100%. The maximum of points leads to 0% score.";
	}

	public override void FixItemsInternal()
	{

	}
	public StringItem StringItem { get; set; } = new StringItem { Label = "Test string", StringValue = "Default value" };
	public IntItem IntItem { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public FloatItem FloatItem { get; set; } = new FloatItem { Label = "Test float", StringValue = "3,14" };
	public OptionsItem OptionsItem { get; set; } = new OptionsItem
	{
		Options = new List<string> { "option 1", "option 2", "option 3" },
		Label = "Select your option:"
	};
	protected override void GenerateScoreInternal()
	{
	}


	protected override void GenerateDetails()
	{
	}
	protected override void ResetInternal()
	{
	}

}
