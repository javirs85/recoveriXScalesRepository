

using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class NineHolePegTest : ScaleBase
{
    public NineHolePegTest()
    {
		
	}

	public override void Init()
	{
		Id = ScalesIDs.NineHPT;
		Name = "Nine hole peg test";
		ShortName = "9HPT";
		AreaOfStudy = "Fine motor skills";
		AutoScoreExplanation = "When both hands take similar amounts of time the score reaches 100%. When one hand uses twice as much time as the other hand score reaches 0%";
		DetailsHeaders.Add("Healthy hand");
		DetailsHeaders.Add("Paretic hand");

		ScoreNormalized = 0;

        Items = new List<ScaleItem>
        {
            new TimeSpanItem { JsonCode = "R", Label = "Right hand:" },
            new TimeSpanItem { JsonCode = "L", Label = "Left hand:" }
        };
    }

	public override void FixItemsInternal()
	{
	}


	protected override void GenerateScoreInternal()
	{
		int leftTime = (int)(Items[0] as TimeSpanItem).Value.TotalMilliseconds;
		int rightTime = (int)(Items[1] as TimeSpanItem).Value.TotalMilliseconds;
		int bigTime; int smallTime;
		if(leftTime > rightTime ) 
		{
			bigTime = leftTime;
			smallTime = rightTime;
		}
		else
		{
			bigTime = rightTime;
			smallTime = leftTime;
		}

		ScoreNormalized = (int)LinearInterpolation(2 * smallTime, smallTime, bigTime);
		ScoreNormalized = Math.Max(ScoreNormalized, 0);
		ScoreNormalized = Math.Min(ScoreNormalized, 100);
		
		if(smallTime == 0 || bigTime == 0)
		{
			ScoreNormalized = 0;
		}

        ScoreRaw = ScoreNormalized;
    }

	protected override void ResetInternal()
	{
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		foreach(var item in Items)
		{
			Details.Add(item.StringValue);
		}
	}

}
