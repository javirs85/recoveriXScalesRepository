

using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class HYClass : ScaleBase
{
    public HYClass()
    {
		Id = ScalesIDs.HYClass;
		Name = "UPDRS - V (Hoehn and Yahr Scale)";
		ShortName = "HYClass";
		AreaOfStudy = "PD disease classification";

		Items = new List<ScaleItem>
		{
			new ComplexOptionsItem
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
			}
		};
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
	}
}
