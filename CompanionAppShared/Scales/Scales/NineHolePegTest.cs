

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class NineHolePegTest : ScaleBase
{
    public NineHolePegTest()
    {
		Id = ScalesIDs.NineHPT;
		Name = "Nine hole peg test";
		ShortName = "9HPT";
		AreaOfStudy = "Fine motor skills";

		DetailsHeaders.Add("Right hand");
		DetailsHeaders.Add("Left hand");

		ScoreNormalized = 0;
	}

	public TimeSpanItem TimeRightHand { get; set; } = new TimeSpanItem { Label = "Right hand:" };
	public TimeSpanItem TimeLeftHand { get; set; } = new TimeSpanItem { Label = "Left hand:" };



	protected override void GenerateScoreInternal()
	{
		Details.Clear();
		Details.Add($"Paretic hand: {TimeRightHand.StringValue}");
		Details.Add($"healthy hand: {TimeLeftHand.StringValue}");
		var floatscore = 0.0;
		if( TimeLeftHand.Value.TotalSeconds > TimeRightHand.Value.TotalSeconds)
			floatscore = (TimeLeftHand.Value.TotalSeconds / TimeRightHand.Value.TotalSeconds) * 100;
		else
			floatscore = (TimeRightHand.Value.TotalSeconds / TimeLeftHand.Value.TotalSeconds) * 100;

		ScoreNormalized = (int)Math.Round(floatscore);

		if(ScoreNormalized < 0) ScoreNormalized = 0;
		if(ScoreNormalized > 100) ScoreNormalized = 100;	
	}

	protected override void ResetInternal()
	{
		TimeRightHand = new TimeSpanItem { Label = "Paretic hand:" };
		TimeLeftHand = new TimeSpanItem { Label = "Healthy hand:" };
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(TimeRightHand.StringValue);
		Details.Add(TimeLeftHand.StringValue);
	}
}
