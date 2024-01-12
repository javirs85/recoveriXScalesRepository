

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class UPDRSIV : ScaleBase
{
    public UPDRSIV()
    {
		Id = ScalesIDs.UPDRSIV;
		Name = "Unified Parkinson's Disease Rating Scale - Section IV";
		ShortName = "UPDRS-IV";
		AreaOfStudy = "Complications therapy";
    }


	public StringItem StringItem { get; set; } = new StringItem { Label = "Test string", StringValue = "Default value" };
	public IntItem IntItem { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public FloatItem FloatItem { get; set; } = new FloatItem { Label = "Test float", StringValue = "3,14" };
	public OptionsItem OptionsItem { get; set; } = new OptionsItem
	{
		Options = new List<string> { "option 1", "option 2", "option 3" },
		Label = "Select your option:"
	};
	protected override bool GenerateScoreInternal()
	{
		return true;
	}
	protected override void ResetInternal()
	{
	}
}
