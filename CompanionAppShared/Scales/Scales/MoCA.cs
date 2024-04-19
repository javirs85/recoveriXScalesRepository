

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

	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(visual);
		Items.Add(Naming);
		Items.Add(Attention);
		Items.Add(Language);
		Items.Add(Abstraction);
		Items.Add(Memory);
		Items.Add(Orientation);
	}


	public IntItem visual { get; set; } = new IntItem { Label = "Visuospatial/Executive (max. 5)", StringValue = "_", MinValue = 0, MaxValue =5 };
	public IntItem Naming { get; set; } = new IntItem { Label = "Naming (max. 3)", StringValue = "_", MinValue = 0, MaxValue = 3 };
	public IntItem Attention { get; set; } = new IntItem { Label = "Attention (max. 6)", StringValue = "_", MinValue = 0, MaxValue = 6 };
	public IntItem Language { get; set; } = new IntItem { Label = "Language (max. 3)", StringValue = "_", MinValue = 0, MaxValue = 3 };
	public IntItem Abstraction { get; set; } = new IntItem { Label = "Abstraction (max. 2)", StringValue = "_", MinValue = 0, MaxValue = 2 };
	public IntItem Memory { get; set; } = new IntItem { Label = "Delayed recall (max. 5)", StringValue = "_", MinValue = 0, MaxValue = 5 };
	public IntItem Orientation { get; set; } = new IntItem { Label = "Orientation (max. 6)", StringValue = "_", MinValue = 0, MaxValue = 6 };


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
