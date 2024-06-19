

using System.Text.Json;
using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class HYClass : ScaleBase
{
	public override void Init()
	{
		Id = ScalesIDs.HYClass;
		Name = "UPDRS - V (Hoehn and Yahr Scale)";
		ShortName = "HYClass";
		AreaOfStudy = "PD disease classification";

		DetailsHeaders.Add("Points");

		Items.Add(HoenYahr);
	}

	public ComplexOptionsItem HoenYahr = new ComplexOptionsItem
	{
		Label = "Hoehn and Yahr Stage",
		Options = new List<Option>
		{
			new Option { Value = 0, Name = "Asymptomatic", Description = string.Empty },
			new Option { Value = 1, Name = "Unilateral involvement only", Description = string.Empty },
			new Option { Value = 2, Name = "Bilateral involvement without impairment of balance", Description = string.Empty },
			new Option { Value = 3, Name = "Mild to moderate involvement; some postural instability but physically independent; needs assistance to recover from pull test", Description = string.Empty },
			new Option { Value = 4, Name = "Severe disability; still able to walk or stand unassisted", Description = string.Empty },
			new Option { Value = 5, Name = "Wheelchair bound or bedridden unless aided", Description = string.Empty }
		}
	};

	public override void FixItemsInternal()
	{
		//Items.Clear();
		//Items.Add(HoenYahr);
	}

	public override void LoadValuesFromDB(string valuesInDb)
	{
		var db = JsonSerializer.Deserialize<List<List<string>>>(valuesInDb);

		HoenYahr.ForceOption(int.Parse(db[1][0]));
	}

	protected override void GenerateScoreInternal()
	{
		ScoreRaw = 0;
		var maxValue = 0;

		foreach (var item in from i in Items
							 where i is ComplexOptionsItem
							 select i as ComplexOptionsItem)
		{
			if (item.SelectedOption is not null)
			{
				ScoreRaw += item.Value;
				maxValue += item.Options.Count - 1;
			}
		}

		if (maxValue == 0)
			ScoreNormalized = 0;
		else
			ScoreNormalized = (int)LinearInterpolation(0, maxValue, ScoreRaw);
	}

	protected override void GenerateDetails()
	{
		Details.Clear();
	}
	protected override void ResetInternal()
	{
		Details.Clear();
		Details.Add(ScoreRaw.ToString());
	}

	public override string ToDBString()
	{
		List<string> labels = new List<string>();
		List<string> values = new List<string>();

		int i = 0;
		foreach (var item in Items)
		{
			if (item is ComplexOptionsItem)
			{
				labels.Add(i.ToString());
				i = i + 1;
				values.Add(((ComplexOptionsItem)item).SelectedOption?.Value.ToString() ?? "0");
			}
		}

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
