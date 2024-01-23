

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class SEADL : ScaleBase
{
    public SEADL()
    {
		Id = ScalesIDs.SEADL;
		Name = "UPDRS - VI (Schwab and England ADL Scale)";
		ShortName = "SEADL";
		AreaOfStudy = "Activities in Daily Living";
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
