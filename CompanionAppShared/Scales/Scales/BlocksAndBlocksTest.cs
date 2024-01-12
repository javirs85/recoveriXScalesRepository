namespace CompanionAppShared.Scales;


public class BlocksAndBlocksTest : ScaleBase
{
    public BlocksAndBlocksTest()
    {
		Id = ScalesIDs.BnBT;
		Name = "Blocks and box test";
		ShortName = "BnBT";
    }

    public int NumberOfBlocksPareticHand { get; set; }
	public int NumberOfBlocksHealthyHand { get; set; }

	protected override bool GenerateScoreInternal()
	{
		throw new NotImplementedException();
	}

	protected override void ResetInternal()
	{
		throw new NotImplementedException();
	}
}
