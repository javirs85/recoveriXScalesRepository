

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TENMWT : ScaleBase
{
    public TENMWT()
    {
		Items = new List<ScaleItem>
		{
			new TimeSpanItem { JsonCode="R1", Label = "Time for central 6 meters:" },
            new TimeSpanItem { JsonCode = "R2", Label = "Time for central 6 meters:" },
            new TimeSpanItem { JsonCode = "R3", Label = "Time for central 6 meters:" }
		};
	}

	public override void Init()
	{
		Id = ScalesIDs.TENMWT;
		Name = "10 Meter Walk Test";
		ShortName = "10MWT";
		AreaOfStudy = "Gait";
		DetailsHeaders.Add("Attempts");
	}



	public override void FixItemsInternal()
	{
	}


	protected override void GenerateScoreInternal()
	{
		//calculate velocity
		//ignore values when equal to zero
		//normalizat amb valors de referencia
		//score = mijana de valors no-zero

		//TODO: Marc provide reference values
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
            var minTime = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
            var maxTime = (int)TimeSpan.FromSeconds(300).TotalMilliseconds;
            ScoreNormalized = (int)LinearInterpolation(maxTime, minTime, ScoreRaw);

        }
			
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		foreach (var item in Items)
		{
			if (item is TimeSpanItem) {
				if((item as TimeSpanItem).Value.TotalSeconds != 0)
                    Details.Add(item.StringValue);
            }
		}
	}
	protected override void ResetInternal()
	{
	}
}
