

using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class NineHolePegTest : ScaleBase
{
    public NineHolePegTest()
    {
		Id = ScalesIDs.NineHPT;
		Name = "Nine hole peg test";
		ShortName = "9HPT";
		AreaOfStudy = "Fine motor skills";

		DetailsHeaders.Add("Healthy hand");
		DetailsHeaders.Add("Paretic hand");

		ScoreNormalized = 0;

		/*
		Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "General information",
				Text = @"
 - The Nine Hole Peg Test should be conducted with the healthy arm first.
 - One practice trial (per arm) should be provided prior to timing the test.
 - Timing should be performed with a stopwatch and recorded in seconds.
 - The stop watch is started when the patient touches the first peg.
 - The stop watch is stopped when the patient places the last peg in the container.
",
				DefaultOpen = true
			},
			new InfoItem
			{
				Label = "Set-up (Mathiowetz et al, 1985):",
				Text = @"
 - A square board with 9 holes,
 - holes are spaced 3.2 cm (1.25 inches) apart
 - each hole is 1.3 cm (.5 inches) deep
 - 9 wooden pegs should be .64 cm (.25 inches) in diameter and 3.2 cm (1.25 inches) long.
 - A container that is constructed from .7 cm (.25 inches) of plywood, sides are attached (13 cm x 13 cm) using nails and glue
 - The peg board should have a mechanism to decrease slippage. Self-adhesive bathtub appliqués were used in the study.
 - The pegboard should be placed in front of the patient, with the container holding the pegs on the side of the healthy hand.
",
		DefaultOpen = false
			},			
			new InfoItem
			{
				Label = "Patient instructions",
				Text = @"
The instructions should be provided while the activity is demonstrated.
The patient's healthy arm is tested first.
Instruct the patient to:
 - put them into the holes in any order until the holes are all filled. Then remove the pegs one at a time and return them to the container. Stabilize the peg board with your left (or right) hand. This is a practice test. See how fast you can put all the pegs in and take them out again. Are you

After the patient performs the practice trial, instruct the patient:
 - **This will be the actual test. The instructions are the same. Work as quickly as you can. Are you ready? Go!** (Start the stop watch when the patient touches the first peg.)
 - While the patietn is performing the test say **Faster**
 - When the patient places the last peg on the board, instruct the patient **Out again ... faster**
 - Stop the stop watch when the last peg hits the container.

Place the container on the opposite side of the pegboard and repeat the instructions with the paretic hand.
",
				DefaultOpen = true
			},
			new InfoItem
			{
				Label = "Modified 9 hole peg test",
				Text = @"
If it is not possible to perform the test with the paretic hand, please use the modified 9HPT.

The goal of m9HPT is to detect any motor improvement using this test. Please
describe his/her performance in Note (e.g. with assistance of unaffected hand).
"
			},
		};

		*/


		FixItemsInternal();
	}

	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(HealthyHand);
		Items.Add(PareticHand);
	}

	public TimeSpanItem HealthyHand { get; set; } = new TimeSpanItem { Label = "Healthy hand:" };
	public TimeSpanItem PareticHand { get; set; } = new TimeSpanItem { Label = "Paretic hand:" };

	ComplexOptionsItem SittingOptions = new ComplexOptionsItem
	{
		Label = "Points",
		InstructionsForTheExaminer = "The goal of m9HPT is to detect any motor improvement using this test. Please describe his/her performance in Note (e.g. with assistance of unaffected hand).",
		Options = new List<Option>
		{
			new Option { Value = 0, Name = "Not possible", Description = "" },
			new Option { Value = 1, Name = "Removed at least one peg", Description = "" },
			new Option { Value = 2, Name = "Removed all with support", Description = "" },
			new Option { Value = 3, Name = "Removed all without support", Description = "" }
		}
	};
	ComplexOptionsItem StandingOptions = new ComplexOptionsItem
	{
		Label = "Points",
		InstructionsForTheExaminer = "The goal of m9HPT is to detect any motor improvement using this test. Please describe his/her performance in Note (e.g. with assistance of unaffected hand).",
		Options = new List<Option>
		{
			new Option { Value = 0, Name = "Not possible", Description = "" },
			new Option { Value = 1, Name = "Removed at least one peg", Description = "" },
			new Option { Value = 2, Name = "Removed all with support", Description = "" },
			new Option { Value = 3, Name = "Removed all without support", Description = "" }
		}
	};
	IntItem PareticItems = new IntItem
	{
		Label = "Number of pegs moved",
		
	};



	protected override void GenerateScoreInternal()
	{
		Details.Clear();
		Details.Add($"Paretic hand: {HealthyHand.StringValue}");
		Details.Add($"healthy hand: {PareticHand.StringValue}");
		var floatscore = 0.0;
		if( PareticHand.Value.TotalSeconds < HealthyHand.Value.TotalSeconds)
			floatscore = (PareticHand.Value.TotalSeconds / HealthyHand.Value.TotalSeconds) * 100;
		else
			floatscore = (HealthyHand.Value.TotalSeconds / PareticHand.Value.TotalSeconds) * 100;

		ScoreNormalized = (int)Math.Round(floatscore);

		if(ScoreNormalized < 0) ScoreNormalized = 0;
		if(ScoreNormalized > 100) ScoreNormalized = 100;	
	}

	protected override void ResetInternal()
	{
 		HealthyHand = new TimeSpanItem { Label = "Healthy hand:" };
		PareticHand = new TimeSpanItem { Label = "Paretic hand:" };
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(HealthyHand.StringValue);
		Details.Add(PareticHand.StringValue);
	}
}
