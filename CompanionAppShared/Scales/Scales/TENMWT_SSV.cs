

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TENMWT_SSV : ScaleBase
{
    public TENMWT_SSV()
    {
		Items = new List<ScaleItem>
		{           new InfoItem
			{
				Label = "Overview",
				Text = @"
# Overview
This version of the 10 meter walk test: self set velocity requests the user to attempt to reach the 10m mark as fast at a velocity that makes them feel confortable.
",
				DefaultOpen = false
			},
            new OptionsItem
            {
                JsonCode = "Device",
                Label = "Assistance device",
                InstructionsForTheExaminer="What type of device does the patient use for mobility assistance? (Select the most similar)",
                Options = new List<string>
                {
                    "None",
                    "Single cane",
                    "Crutch",
                    "Quad cane",
                    "Walker"
                }
            },
            new TimeSpanItem { 
				JsonCode="SSV_1", 
				Label = "Time for central 6 meters in SSV", 
				InstructionsForThePatient="Walk at your own comfortable walking pace and stop when you reach the far mark",
				InstructionsForTheExaminer="This field is not mandatory"
			},
			new TimeSpanItem {
				JsonCode="SSV_2",
				Label = "Time for central 6 meters in SSV",
				InstructionsForThePatient="Walk at your own comfortable walking pace and stop when you reach the far mark",
				InstructionsForTheExaminer="This field is not mandatory"
			},
			new TimeSpanItem {
				JsonCode="SSV_3",
				Label = "Time for central 6 meters in SSV",
				InstructionsForThePatient="Walk at your own comfortable walking pace and stop when you reach the far mark",
				InstructionsForTheExaminer="This field is not mandatory"
			}
		};
	}

	public override bool CheckMissingItems()
	{
		//we check that at least one run has been measured

		MissingItemsText = "At least one measure must be performed";

		foreach (var item in from i in Items
							 where i is TimeSpanItem
							 select i as TimeSpanItem)
			if (item.Value.TotalSeconds > 0)
				return false;

		return true;
	}

	public override void Init()
	{
		Id = ScalesIDs.TENMWT_SSV;
		Name = "10 Meter Walk Test: Selft set velocity";
		ShortName = "10MWT_SSV";
		AreaOfStudy = "Gait";
		DetailsHeaders.Add("Times");
		AutoScoreExplanation = "Score reaches 100% for values smaller than 7s and 0% for values larger than 60s.<br/>Multiple measures are not mandatory. Untaken measures won't affect averages";
	}



	public override void FixItemsInternal()
	{
	}


	protected override void GenerateScoreInternal()
	{
		int minRef = 7;
		int maxRef = 60;

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
