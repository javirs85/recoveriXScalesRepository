

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class ERP : ScaleBase
{
    public ERP()
    {
		Id = ScalesIDs.ERP;
		Name = "Evoked Related Potentials";
		ShortName = "ERP";
		AreaOfStudy = "Brain responses";
    }


	public override void FixItemsInternal()
	{
		Items.Clear();
	}
	public override void Init()
	{
	}


	public StringItem StringItem { get; set; } = new StringItem
    {
        JsonCode = "TestString",
        Label = "Test string", StringValue = "Default value" };
	public IntItem IntItem { get; set; } = new IntItem
    {
        JsonCode = "TestInt",
        Label = "Test int", StringValue = "12" };
	public FloatItem FloatItem { get; set; } = new FloatItem
    {
        JsonCode = "TestFloat",
        Label = "Test float", StringValue = "3,14" };
	public OptionsItem OptionsItem { get; set; } = new OptionsItem
    {
        JsonCode = "TestOptions",
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


	public override Dictionary<string, string> ToDBDictionary()
	{
        var dic = new Dictionary<string, string>();
        dic.Add("NotDone", "Not coded yet");
        return dic;
    }

}
