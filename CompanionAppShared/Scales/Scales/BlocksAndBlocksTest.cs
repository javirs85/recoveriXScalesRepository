using System.Text.Json;

namespace CompanionAppShared.Scales;


public class BlocksAndBlocksTest : ScaleBase
{
    public BlocksAndBlocksTest()
    {
		
    }

	public override void Init()
	{
		Id = ScalesIDs.BnBT;
		Name = "Blocks and box test";
		ShortName = "BnBT";
		AreaOfStudy = "Gross motor skills";
		DetailsHeaders.Add("Paretic hand");
		DetailsHeaders.Add("Healthy hand");

		Items = new List<ScaleItem>();
	}


	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(NumberOfBlocksPareticHand);
		Items.Add(NumberOfBlocksHealthyHand);
	}

	public IntItem NumberOfBlocksPareticHand { get; set; } = new IntItem { Label = "Paretic hand", StringValue = "0" };
	public IntItem NumberOfBlocksHealthyHand { get; set; } = new IntItem { Label = "Healthy hand", StringValue = "0" };

	protected override void GenerateScoreInternal()
	{
		ScoreRaw = NumberOfBlocksPareticHand.Value;
		if(NumberOfBlocksHealthyHand.Value == 0)
			ScoreNormalized = 0; 
		else
			ScoreNormalized = (100*NumberOfBlocksPareticHand.Value) /NumberOfBlocksHealthyHand.Value;
	}
	public override void LoadValuesFromDB(string valuesInDb)
	{
		throw new NotImplementedException();
	}

	protected override void ResetInternal()
	{
		NumberOfBlocksPareticHand = new IntItem { Label = "Paretic hand", StringValue = "0" };
		NumberOfBlocksHealthyHand = new IntItem { Label = "Healthy hand", StringValue = "0" };
	}

	protected override void GenerateDetails()
	{
		Details.Add(NumberOfBlocksPareticHand.StringValue);
		Details.Add(NumberOfBlocksHealthyHand.StringValue);
	}

	public override string ToDBString()
	{		
		return CreateDBItem(
			new List<string>
			{
				"HealthyHand",
				"PareticHand"
			}, 
			new List<string>
			{
				NumberOfBlocksHealthyHand.StringValue,
				NumberOfBlocksPareticHand.StringValue
			});
	}

	public override void FromDBString(string dbString)
	{
		var dbItems = ParseDbString(dbString, 2);

		NumberOfBlocksHealthyHand.StringValue = dbItems[0];
		NumberOfBlocksPareticHand.StringValue = dbItems[1];
	}
}
