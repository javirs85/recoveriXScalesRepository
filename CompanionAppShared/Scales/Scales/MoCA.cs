

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class MoCA : ScaleBase
{
    public MoCA()
    {
		
    }

	public override void Init()
	{
		Id = ScalesIDs.MoCA;
		Name = "Montreal cognitive assessment";
		ShortName = "MoCA";
		AreaOfStudy = "Cognitive status";
	}

	public override void FixItemsInternal()
	{
		if (Items.Count == 0)
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

	public override void LoadValuesFromDB(string valuesInDb)
	{
		var dbItems = ParseDbString(valuesInDb, 7);

		visual.StringValue = dbItems[0];
		Naming.StringValue = dbItems[1];
		Attention.StringValue = dbItems[2];
		Language.StringValue = dbItems[3];
		Abstraction.StringValue = dbItems[4];
		Memory.StringValue = dbItems[5];
		Orientation.StringValue = dbItems[6];

		FixItemsInternal();
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add($"{visual.Value}, {Naming.Value}, {Attention.Value}, {Language.Value}, {Abstraction.Value}, {Memory.Value}, {Orientation.Value}");
	}

	protected override void ResetInternal()
	{
	}

	public override string ToDBString()
	{

		List<string> labels = new List<string>();
		List<string> values = new List<string>();

		labels.Add("visual");
		values.Add(visual.StringValue);
		labels.Add("Naming");
		values.Add(Naming.StringValue);
		labels.Add("Attention");
		values.Add(Attention.StringValue);
		labels.Add("Language");
		values.Add(Language.StringValue);
		labels.Add("Abstraction");
		values.Add(Abstraction.StringValue);
		labels.Add("Memory");
		values.Add(Memory.StringValue);
		labels.Add("Orientation");
		values.Add(Orientation.StringValue);

		return CreateDBItem(labels, values);
	}

	public override void FromDBString(string dbString)
	{
		var dbItems = ParseDbString(dbString, Items.Count);
		int i = 0;
		foreach (var dbItem in dbItems)
		{
			Items[i].StringValue = dbItem;
			i++;
		}
	}
}
