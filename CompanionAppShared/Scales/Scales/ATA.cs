

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class ATA : ScaleBase
{
    public ATA()
    {
		Id = ScalesIDs.ATA;
		Name = "Accelerometer Tremor Assessment";
		ShortName = "ATA";
		AreaOfStudy = "Brain responses";
    }
	public override void FixItemsInternal()
	{
	}

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
