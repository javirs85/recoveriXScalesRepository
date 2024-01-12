

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class PDQ39 : ScaleBase
{
    public PDQ39()
    {
		Id = ScalesIDs.PDQ39;
		Name = "Parkinson's Disease Questionnaire";
		ShortName = "PDQ39";
		AreaOfStudy = "Impact of the disease";
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
