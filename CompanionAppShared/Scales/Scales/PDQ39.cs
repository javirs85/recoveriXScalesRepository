﻿

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class PDQ39 : ScaleBase
{
	public PDQ39()
	{

	}

	public override void Init()
	{
		Id = ScalesIDs.PDQ39;
		Name = "Parkinson's Disease Questionnaire";
		ShortName = "PDQ39";
		AreaOfStudy = "Impact of the disease";

		DetailsHeaders = new List<string> { "Points" };
		AutoScoreExplanation = "With 0 points the score reaches 100%. The maximum of points leads to 0% score.";

		Items = new List<ScaleItem>
		{
			new ComplexOptionsItem
			{
				JsonCode="1",
				Label = "1. Had difficulty doing the leisure activities which you would like to do?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description="" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="2",
				Label = "2. Had difficulty looking after your home, e.g. DIY, housework, cooking?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="3",
				Label = "3. Had difficulty carrying bags of shopping?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="4",
				Label = "4. Had problems walking half a mile?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="5",
				Label = "5. Had problems walking 100 yards?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="6",
				Label = "6. Had problems getting around the house as easily as you would like?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="7",
				Label = "7. Had difficulty getting around in public?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="8",
				Label = "8. Needed someone else to accompany you when you went out?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="9",
				Label = "9. Felt frightened or worried about falling over in public?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="10",
				Label = "10. Been confined to the house more than you would like?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="11",
				Label = "11. Had difficulty washing yourself?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="12",
				Label = "12. Had difficulty dressing yourself?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="13",
				Label = "13. Had problems doing up buttons or shoe laces?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="14",
				Label = "14. Had problems writing clearly?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="15",
				Label = "15. Had difficulty cutting up your food?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="16",
				Label = "16. Had difficulty holding a drink without spilling it?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="17",
				Label = "17. Felt depressed?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="18",
				Label = "18. Felt isolated and lonely?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="19",
				Label = "19. Felt weepy or tearful?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="20",
				Label = "20. Felt angry or bitter?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="21",
				Label = "21. Felt anxious?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="22",
				Label = "22. Felt worried about your future?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="23",
				Label = "23. Felt you had to conceal your Parkinson’s from people?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="24",
				Label = "24. Avoided situations which involve eating or drinking in public?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="25",
				Label = "25. Felt embarrassed in public due to having Parkinson’s disease?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="26",
				Label = "26. Felt worried by other people’s reaction to you?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="27",
				Label = "27. Had problems with your close personal relationships?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="28",
				Label = "28. Lacked support in the ways you need from your spouse or partner? If you do not have a spouse or partner, please tick here",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="29",
				Label = "29. Lacked support in the ways you need from your family or close friends?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="30",
				Label = "30. Unexpectedly fallen asleep during the day?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="31",
				Label = "31. Had problems with your concentration, e.g. when reading or watching TV?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="32",
				Label = "32. Felt your memory was bad?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="33",
				Label = "33. Had distressing dreams or hallucinations?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="34",
				Label = "34. Had difficulty with your speech?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="35",
				Label = "35. Felt unable to communicate with people properly?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="36",
				Label = "36. Felt ignored by people?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="37",
				Label = "37. Had painful muscle cramps or spasms?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="38",
				Label = "38. Had aches and pains in your joints or body?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			},
			new ComplexOptionsItem
			{
				JsonCode="39",
				Label = "39. Felt unpleasantly hot or cold?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Never", Description = "" },
					new Option { Value = 1, Name = "Occasionally", Description = "" },
					new Option { Value = 2, Name = "Sometimes", Description = "" },
					new Option { Value = 3, Name = "Often", Description = "" },
					new Option { Value = 4, Name = "Always or cannot do at all", Description = "" }
				}
			}
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
			if (item.SelectedOption is not null && item.SelectedOption.Value != -1)
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
