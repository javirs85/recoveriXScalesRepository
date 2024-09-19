

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TUG : ScaleBase
{
	//Check GenerateScoreInternal for details

    public TUG()
    {
		
    }

	public override void Init()
	{
		Id = ScalesIDs.TUG;
		Name = "Timed Up & Go";
		ShortName = "TUG";
		AreaOfStudy = "Balance and gait";

		DetailsHeaders.Add("Time (m)");
		AutoScoreExplanation = "Score reaches 100% for values smaller than 9s and 0% for values larger than 80s.<br/>Multiple measures are not mandatory. Untaken measures won't affect averages";

		Items = new List<ScaleItem>
		{
			new TimeSpanItem { JsonCode="R1", Label = "Time:" },
			new TimeSpanItem { JsonCode = "R2", Label = "Time:" },
			new TimeSpanItem { JsonCode = "R3", Label = "Time:" }
		};
	}

	public override void FixItemsInternal()
	{
	}

	protected override void GenerateScoreInternal()
	{
		int minRef = 9;
		int maxRef = 80;

		ScoreRaw = 0;
		int measures = 0;
		foreach (var item in from i in Items
							 where i is TimeSpanItem
							 select i as TimeSpanItem)
		{
			if (item.Value.TotalSeconds != 0)
			{
				ScoreRaw += (int)item.Value.TotalMilliseconds;
				measures++;
			}
		}
		if (measures == 0)
		{
			ScoreRaw = 0;
			ScoreNormalized = 0;
		}
		else
		{
			ScoreRaw /= measures;
			var minTime = (int)TimeSpan.FromSeconds(minRef).TotalMilliseconds;
			var maxTime = (int)TimeSpan.FromSeconds(maxRef).TotalMilliseconds;
			ScoreNormalized = (int)LinearInterpolation(maxTime, minTime, ScoreRaw);

		}
	}

	protected override void ResetInternal()
	{
	}

	protected override void GenerateDetails()
	{
		Details.Clear();
		foreach (var item in Items)
		{
			if (item is TimeSpanItem)
			{
				if ((item as TimeSpanItem).Value.TotalSeconds != 0)
					Details.Add(item.StringValue);
			}
		}
	}
}
