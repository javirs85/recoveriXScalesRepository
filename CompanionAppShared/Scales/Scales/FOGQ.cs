

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;

public class FOGQ : ScaleBase
{
    public FOGQ()
    {
		Id = ScalesIDs.FOGQ;
		Name = "Freezing Of Gait Questionnaire";
		ShortName = "FOGQ";
		AreaOfStudy = "Freezing of gait";

		Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "Overview",
				Text = @"
# Overview
Answers should be based on the last week

# Filling it in
When choosing what option applies from the list always start with the worst one and, if it does not apply, go to the next.
",
				DefaultOpen = true
			},
			new ComplexOptionsItem
            {
                JsonCode = "1",
                Label = "1.During your worst state—Do you walk:",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "Normally.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Somewhat slow.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Slow but fully independent.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Need assistance or walking aid.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to walk."
							},
						}
			},
			new ComplexOptionsItem
            {
                JsonCode = "2",
                Label = "2. Are your gait difficulties affecting your daily activities and independence?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "Normally.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Mildly.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Moderately.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Severely.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to walk."
							},
						}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3",
                Label = "3. Do you feel that your feet get glued to the floor while walking, making a turn or when trying to initiate walking (freezing)?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Never",
								Description = "Never.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Very rarely",
								Description = "about once a month.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Rarely",
								Description = "about once a week.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Often",
								Description = "about once a day.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Always",
								Description = "whenever walking."
							},
						}
			},
			new ComplexOptionsItem
            {
                JsonCode = "4",
                Label = "4. How long is your longest freezing episode?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Never happened",
								Description = "Never happened.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "1–2 s",
								Description = "1–2 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "3–10 s",
								Description = "3–10 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "11–30 s",
								Description = "11–30 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Unable",
								Description = "Unable to walk for more than 30 s."
							},
						}
			},
			new ComplexOptionsItem
            {
                JsonCode = "5",
                Label = "5. How long is your typical start hesitation episode (freezing when initiating the first step)?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "None",
								Description = "None.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Takes longer than 1s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Takes longer than 3s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Takes longer than 10s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Takes longer than 30s to start walking."
							},
						}
			},
			new ComplexOptionsItem
            {
                JsonCode = "6",
                Label = "6. How long is your typical turning hesitation: (freezing when turning)",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "None.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Resume turning in 1–2 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Resume turning in 3–10 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Resume turning in 10–30 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to resume turning for more than 30s."
							},
						}
			},
		};
	}


	public override void Init()
	{
		Id = ScalesIDs.FOGQ;
		Name = "Freezing Of Gait Questionnaire";
		ShortName = "FOGQ";
		AreaOfStudy = "Freezing of gait";
		DetailsHeaders.Clear();
        DetailsHeaders.Add("Points");

        Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "Overview",
				Text = @"
# Overview
Answers should be based on the last week

# Filling it in
When choosing what option applies from the list always start with the worst one and, if it does not apply, go to the next.
",
				DefaultOpen = true
			},
			new ComplexOptionsItem
			{
				Label = "1.During your worst state—Do you walk:",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "Normally.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Somewhat slow.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Slow but fully independent.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Need assistance or walking aid.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to walk."
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "2. Are your gait difficulties affecting your daily activities and independence?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "Normally.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Mildly.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Moderately.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Severely.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to walk."
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "3. Do you feel that your feet get glued to the floor while walking, making a turn or when trying to initiate walking (freezing)?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Never",
								Description = "Never.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Very rarely",
								Description = "about once a month.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Rarely",
								Description = "about once a week.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Often",
								Description = "about once a day.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Always",
								Description = "whenever walking."
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "4. How long is your longest freezing episode?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Never happened",
								Description = "Never happened.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "1–2 s",
								Description = "1–2 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "3–10 s",
								Description = "3–10 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "11–30 s",
								Description = "11–30 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Unable",
								Description = "Unable to walk for more than 30 s."
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "5. How long is your typical start hesitation episode (freezing when initiating the first step)?",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "None",
								Description = "None.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Takes longer than 1s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Takes longer than 3s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Takes longer than 10s to start walking.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Takes longer than 30s to start walking."
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "6. How long is your typical turning hesitation: (freezing when turning)",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "None.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Resume turning in 1–2 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Resume turning in 3–10 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Resume turning in 10–30 s.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Unable to resume turning for more than 30s."
							},
						}
			},
		};
	}
	
	public override void FixItemsInternal()
	{
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
			ScoreNormalized = (int)LinearInterpolation(maxValue, 0, ScoreRaw);
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(ScoreRaw.ToString());
	}
	protected override void ResetInternal()
	{
	}
}
