

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class MoCA : ScaleBase
{
    public MoCA()
    {
		Id = ScalesIDs.MoCA;
		Name = "Montreal cognitive assessment";
		ShortName = "MoCA";
		AreaOfStudy = "Cognitive status";
    }


	public IntItem visual { get; set; } = new IntItem { Label = "Visuospatial/Executive (max. 5)", StringValue = "_" };
	public IntItem Naming { get; set; } = new IntItem { Label = "Naming (max. 3)", StringValue = "_" };
	public IntItem Attention { get; set; } = new IntItem { Label = "Attention (max. 6)", StringValue = "_" };
	public IntItem Language { get; set; } = new IntItem { Label = "Language (max. 3)", StringValue = "_" };
	public IntItem Abstraction { get; set; } = new IntItem { Label = "Abstraction (max. 2)", StringValue = "_" };
	public IntItem Memory { get; set; } = new IntItem { Label = "Delayed recall (max. 5)", StringValue = "_" };
	public IntItem Orientation { get; set; } = new IntItem { Label = "Orientation (max. 6)", StringValue = "_" };


	protected override void GenerateScoreInternal()
	{
		ScoreRaw = visual.Value + Naming.Value + Attention.Value + Language.Value + Abstraction.Value + Memory.Value+ Orientation.Value;
		ScoreNormalized = (int)((float)ScoreRaw / 30.0f * 100);
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add($"{visual.Value}, {Naming.Value}, {Attention.Value}, {Language.Value}, {Abstraction.Value}, {Memory.Value}, {Orientation.Value}");
	}

	protected override void ResetInternal()
	{
	}
}
