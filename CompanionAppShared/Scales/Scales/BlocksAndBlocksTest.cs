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

	public IntItem NumberOfBlocksPareticHand { get; set; } = new IntItem
    {
        JsonCode = "PareticBlocks",
        Label = "Paretic hand", StringValue = "0" };
	public IntItem NumberOfBlocksHealthyHand { get; set; } = new IntItem
    {
        JsonCode = "HealthyBlocks",
        Label = "Healthy hand", StringValue = "0" };

	protected override void GenerateScoreInternal()
	{
		ScoreRaw = NumberOfBlocksPareticHand.Value;
		if(NumberOfBlocksHealthyHand.Value == 0)
			ScoreNormalized = 0; 
		else
			ScoreNormalized = (100*NumberOfBlocksPareticHand.Value) /NumberOfBlocksHealthyHand.Value;
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

}
