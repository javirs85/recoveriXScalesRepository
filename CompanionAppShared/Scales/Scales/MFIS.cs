

using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class MFIS : ScaleBase
{
    public MFIS()
    {
		
	}

	public override void Init()
	{
		Id = ScalesIDs.MFIS;
		Name = "Modified Fatigue Impact Scale";
		ShortName = "MFIS";
		AreaOfStudy = "Fatigue";

		DetailsHeaders = new List<string> { "Points" };

		Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "Overview",
				Text = @"
Fatigue is a feeling of physical tiredness and lack of energy that many people experience from time to time. But people who have medical conditions like MS
experience stronger feelings of fatigue more often and with greater impact than others.

Following is a list of statements that describe the effects of fatigue. Please read each statement carefully, the circle the one number that best indicates how often fatigue has affected you in this way during the past 4 weeks. (If you need help in marking your responses, tell the interviewer the number of the best response.) Please answer every question. If you are not sure which answer to select choose the one answer that comes closest to describing you. Ask the interviewer to explain any words or phrases that you do not understand.

# Answer the questions
Because of my fatigue during the past 4 weeks ...
",
				DefaultOpen = true
			},
			new ComplexOptionsItem
			{
				Label = "1. I have been less alert",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2. I have had difficulty paying attention for long periods of time",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "3. I have been unable to think clearly",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "4. I have been clumsy and uncoordinated",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "5. I have been forgetful",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "6. I have had to pace myself in my physical activities",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "7. I have been less motivated to do anything\r\nthat requires physical effort",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "8. I have been less motivated to participate in\r\nsocial activities.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "9. I have been limited in my ability to do things away from home",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "10. I have trouble maintaining physical effort for long periods",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "11. I have had difficulty making decisions",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "12. I have been less motivated to do anything that requires thinking",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "13. My muscles have felt weak",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "14. I have been physically uncomfortable",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "15. I have had trouble finishing tasks that require thinking",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "16. I have had difficulty organizing my thought when doing things at home or at work",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "17. I have been less able to complete tasks that require physical effort",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "18. My thinking has been slowed down",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "19. I have had trouble concentrating",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "20. I have limited my physical activities",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "21. I have needed to rest more often or for longer periods.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "Never." },
					new Option { Value = 1, Name = "Rarely", Description = "Rarely." },
					new Option { Value = 2, Name = "Sometimes", Description = "Sometimes." },
					new Option { Value = 3, Name = "Often", Description = "Often." },
					new Option { Value = 4, Name = "Almost Always", Description = "Almost Always." }
				}
			},
		};
	}

	public override void FixItemsInternal()
	{

	}


	public override void LoadValuesFromDB(string valuesInDb) => FromDBStrinngToListOfComplexOptions(valuesInDb);

	protected override void GenerateScoreInternal()
	{
		ScoreRaw = 0;
		var maxValue = 0;

		foreach (var item in from i in Items
							 where i is ComplexOptionsItem
							 select i as ComplexOptionsItem)
		{
			if (item.SelectedOption is not null && item.SelectedOption.Value != -1)
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
		Details.Add(ScoreRaw.ToString());
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
				values.Add(((ComplexOptionsItem)item).SelectedOption?.Value.ToString() ?? "-1");
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
