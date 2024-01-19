﻿

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TENMWT : ScaleBase
{
    public TENMWT()
    {
		Id = ScalesIDs.TENMWT;
		Name = "10 Meter Walk Test";
		ShortName = "10MWT";
		AreaOfStudy = "Gait";
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
