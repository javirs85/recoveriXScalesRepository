

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class SEADL : ScaleBase
{
    public SEADL()
    {
		
    }
	public override void Init()
	{
		Id = ScalesIDs.SEADL;
		Name = "UPDRS - VI (Schwab and England ADL Scale)";
		ShortName = "SEADL";
		AreaOfStudy = "Activities in Daily Living";
	}

	public override void FixItemsInternal()
	{

	}
	public StringItem StringItem { get; set; } = new StringItem { Label = "Test string", StringValue = "Default value" };
	public IntItem IntItem { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public FloatItem FloatItem { get; set; } = new FloatItem { Label = "Test float", StringValue = "3,14" };
	public OptionsItem OptionsItem { get; set; } = new OptionsItem
	{
		Options = new List<string> { "option 1", "option 2", "option 3" },
		Label = "Select your option:"
	};
	protected override void GenerateScoreInternal()
	{
	}

	public override void LoadValuesFromDB(string valuesInDb)
	{
	}

	protected override void GenerateDetails()
	{
	}
	protected override void ResetInternal()
	{
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
