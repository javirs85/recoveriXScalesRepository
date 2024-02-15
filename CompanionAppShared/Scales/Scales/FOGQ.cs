

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;

public class FOGQ : ScaleBase
{
    public FOGQ()
    {
		Id = ScalesIDs.FOGQ;
		Name = "Freezing Of Gait Questionnaire";
		ShortName = "FOGQ";
		AreaOfStudy = "Freezing of gait";
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
		//igual que el PDQ39
	}
	protected override void GenerateDetails()
	{
	}
	protected override void ResetInternal()
	{
	}
}
