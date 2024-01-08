

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class miniBESTest : ScaleBase
{
    public miniBESTest()
    {
		Id = ScalesIDs.miniBESTest;
		Name = "Mini Balance Evaluation Test";
		ShortName = "mini BESTest";
		AreaOfStudy = "Balance";
    }

	public TimeSpanItem TimePareticHand { get; set; } = new TimeSpanItem { Label = "Paretic hand:" };
	public TimeSpanItem TimeHealthyHand { get; set; } = new TimeSpanItem { Label = "Healthy hand:" };

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
