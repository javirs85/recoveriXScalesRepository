

using System.IO;
using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class UPDRSII : ScaleBase
{
	public UPDRSII()
	{
		Id = ScalesIDs.UPDRSII;
		Name = "Unified Parkinson's Disease Rating Scale - Section II";
		ShortName = "UPDRS-II";
		AreaOfStudy = "Activities in Daily Living";

		Items = new List<ScaleItem>
		{
			new ComplexOptionsItem
			{
				Label = "2.1 SPEECH",
				InstructionsForThePatient = "Over the past week, have you had problems with your speech?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "My speech is soft, slurred or uneven, but it does not cause others to ask me to repeat myself." },
					new Option { Value = 2, Name = "Mild", Description = "My speech causes people to ask me to occasionally repeat myself, but not every day." },
					new Option { Value = 3, Name = "Moderate", Description = "My speech is unclear enough that others ask me to repeat myself every day even though most of my speech is understood." },
					new Option { Value = 4, Name = "Severe", Description = "Most or all of my speech cannot be understood." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.1 SPEECH",
				InstructionsForThePatient = "Over the past week, have you had problems with your speech?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "My speech is soft, slurred or uneven, but it does not cause others to ask me to repeat myself." },
					new Option { Value = 2, Name = "Mild", Description = "My speech causes people to ask me to occasionally repeat myself, but not every day." },
					new Option { Value = 3, Name = "Moderate", Description = "My speech is unclear enough that others ask me to repeat myself every day even though most of my speech is understood." },
					new Option { Value = 4, Name = "Severe", Description = "Most or all of my speech cannot be understood." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.2 SALIVA AND DROOLING",
				InstructionsForThePatient = "Over the past week, have you usually had too much saliva during when you are awake or when you sleep?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I have too much saliva, but do not drool." },
					new Option { Value = 2, Name = "Mild", Description = "I have some drooling during sleep, but none when I am awake." },
					new Option { Value = 3, Name = "Moderate", Description = "I have some drooling when I am awake, but I usually do not need tissues or a handkerchief." },
					new Option { Value = 4, Name = "Severe", Description = "I have so much drooling that I regularly need to use tissues or a handkerchief to protect my clothes." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.3 CHEWING AND SWALLOWING",
				InstructionsForThePatient = "Over the past week, have you usually had problems swallowing pills or eating meals? Do you need your pills cut or crushed or your meals to be made soft, chopped, or blended to avoid choking?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "I am aware of slowness in my chewing or increased effort at swallowing, but I do not choke or need to have my food specially prepared." },
					new Option { Value = 2, Name = "Mild", Description = "I need to have my pills cut or my food specially prepared because of chewing or swallowing problems, but I have not choked over the past week." },
					new Option { Value = 3, Name = "Moderate", Description = "I choked at least once in the past week." },
					new Option { Value = 4, Name = "Severe", Description = "Because of chewing and swallowing problems, I need a feeding tube." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.4 EATING TASKS",
				InstructionsForThePatient = "Over the past week, have you usually had troubles handling your food and using eating utensils? For example, do you have trouble handling finger foods or using forks, knives, spoons, chopsticks?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am slow, but I do not need any help handling my food and have not had food spills while eating." },
					new Option { Value = 2, Name = "Mild", Description = "I am slow with my eating and have occasional food spills. I may need help with a few tasks such as cutting meat." },
					new Option { Value = 3, Name = "Moderate", Description = "I need help with many eating tasks but can manage some alone." },
					new Option { Value = 4, Name = "Severe", Description = "I need help for most or all eating tasks." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.5 DRESSING",
				InstructionsForThePatient = "Over the past week, have you usually had problems dressing? For example, are you slow or do you need help with buttoning, using zippers, putting on or taking off your clothes or jewelry?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am slow, but I do not need help." },
					new Option { Value = 2, Name = "Mild", Description = "I am slow and need help for a few dressing tasks (buttons, bracelets)." },
					new Option { Value = 3, Name = "Moderate", Description = "I need help for many dressing tasks." },
					new Option { Value = 4, Name = "Severe", Description = "I need help for most or all dressing tasks." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.6 HYGIENE",
				InstructionsForThePatient = "Over the past week, have you usually been slow or do you need help with washing, bathing, shaving, brushing teeth, combing your hair, or with other personal hygiene?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am slow, but I do not need any help." },
					new Option { Value = 2, Name = "Mild", Description = "I need someone else to help me with some hygiene tasks." },
					new Option { Value = 3, Name = "Moderate", Description = "I need help for many hygiene tasks." },
					new Option { Value = 4, Name = "Severe", Description = "I need help for most or all of my hygiene tasks." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.7 HANDWRITING",
				InstructionsForThePatient = "Over the past week, have people usually had trouble reading your handwriting?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "My writing is slow, clumsy or uneven, but all words are clear." },
					new Option { Value = 2, Name = "Mild", Description = "Some words are unclear and difficult to read." },
					new Option { Value = 3, Name = "Moderate", Description = "Many words are unclear and difficult to read." },
					new Option { Value = 4, Name = "Severe", Description = "Most or all words cannot be read." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.8 DOING HOBBIES AND OTHER ACTIVITIES",
				InstructionsForThePatient = "Over the past week, have you usually had trouble doing your hobbies or other things that you like to do?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am a bit slow but do these activities easily." },
					new Option { Value = 2, Name = "Mild", Description = "I have some difficulty doing these activities." },
					new Option { Value = 3, Name = "Moderate", Description = "I have major problems doing these activities, but still do most." },
					new Option { Value = 4, Name = "Severe", Description = "I am unable to do most or all of these activities." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.9 TURNING IN BED",
				InstructionsForThePatient = "Over the past week, do you usually have trouble turning over in bed?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I have a bit of trouble turning, but I do not need any help." },
					new Option { Value = 2, Name = "Mild", Description = "I have a lot of trouble turning and need occasional help from someone else." },
					new Option { Value = 3, Name = "Moderate", Description = "To turn over I often need help from someone else." },
					new Option { Value = 4, Name = "Severe", Description = "I am unable to turn over without help from someone else." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.10 TREMOR",
				InstructionsForThePatient = "Over the past week, have you usually had shaking or tremor?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all. I have no shaking or tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Shaking or tremor occurs but does not cause problems with any activities." },
					new Option { Value = 2, Name = "Mild", Description = "Shaking or tremor causes problems with only a few activities." },
					new Option { Value = 3, Name = "Moderate", Description = "Shaking or tremor causes problems with many of my daily activities." },
					new Option { Value = 4, Name = "Severe", Description = "Shaking or tremor causes problems with most or all activities." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.11 GETTING OUT OF BED, A CAR, OR A DEEP CHAIR",
				InstructionsForThePatient = "Over the past week, have you usually had trouble getting out of bed, a car seat, or a deep chair?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am slow or awkward, but I usually can do it on my first try." },
					new Option { Value = 2, Name = "Mild", Description = "I need more than one try to get up or need occasional help." },
					new Option { Value = 3, Name = "Moderate", Description = "I sometimes need help to get up, but most times I can still do it on my own." },
					new Option { Value = 4, Name = "Severe", Description = "I need help most or all of the time." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.12 WALKING AND BALANCE",
				InstructionsForThePatient = "Over the past week, have you usually had problems with balance and walking?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I am slightly slow or may drag a leg. I never use a walking aid." },
					new Option { Value = 2, Name = "Mild", Description = "I occasionally use a walking aid, but I do not need any help from another person." },
					new Option { Value = 3, Name = "Moderate", Description = "I usually use a walking aid (cane, walker) to walk safely without falling. However, I do not usually need the support of another person." },
					new Option { Value = 4, Name = "Severe", Description = "I usually use the support of another person to walk safely without falling." }
				}
			},
			new ComplexOptionsItem
			{
				Label = "2.13 FREEZING",
				InstructionsForThePatient = "Over the past week, on your usual day when walking, do you suddenly stop or freeze as if your feet are stuck to the floor?",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Not at all (no problems)." },
					new Option { Value = 1, Name = "Slight", Description = "I briefly freeze, but I can easily start walking again. I do not need help from someone else or a walking aid (cane or walker) because of freezing." },
					new Option { Value = 2, Name = "Mild", Description = "I freeze and have trouble starting to walk again, but I do not need someone’s help or a walking aid (cane or walker) because of freezing." },
					new Option { Value = 3, Name = "Moderate", Description = "When I freeze I have a lot of trouble starting to walk again and, because of freezing, I sometimes need to use a walking aid or need someone else’s help." },
					new Option { Value = 4, Name = "Severe", Description = "Because of freezing, most or all of the time, I need to use a walking aid or someone’s help." }
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
