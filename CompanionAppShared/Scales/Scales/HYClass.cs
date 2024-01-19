

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class HYClass : ScaleBase
{
    public HYClass()
    {
		Id = ScalesIDs.HYClass;
		Name = "UPDRS - V (Hoehn and Yahr Scale)";
		ShortName = "HYClass";
		AreaOfStudy = "PD disease classification";
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
