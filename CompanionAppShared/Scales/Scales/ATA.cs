

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

	public override void Init()
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

	public override void LoadValuesFromDB(string valuesInDb)
	{

	}

	public override string ToDBString()
	{
		return CreateDBItem(
			new List<string>
			{
				"not done",
			},
			new List<string>
			{
				"not done",
			});
	}

	public override void FromDBString(string dbString)
	{
		var dbItems = ParseDbString(dbString, 2);

		/*
		NumberOfBlocksHealthyHand.StringValue = dbItems[0];
		NumberOfBlocksPareticHand.StringValue = dbItems[1];
		*/
	}
}
