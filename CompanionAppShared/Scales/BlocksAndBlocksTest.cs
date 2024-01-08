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
}
