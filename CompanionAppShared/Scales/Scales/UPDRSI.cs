

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class UPDRSI : ScaleBase
{
	public UPDRSI()
	{
		Id = ScalesIDs.UPDRSI;
		Name = "Unified Parkinson's Disease Rating Scale - Section I";
		ShortName = "UPDRS-I";
		AreaOfStudy = "Mentation, Behavior Mood";

		Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "Overview",
				Text = @"
# Overview
This portion of the scale assesses the non-motor impact of Parkinson's disease (PD) on patients’ experiences of daily living. There are 13 questions. Part IA is administered by the rater (six questions) and focuses on complex behaviors. Part IB is a component of the self-administered Patient Questionnaire that covers seven questions on non-motor experiences of daily living.

## Part IA
In administering Part IA, the examiner should use the following guidelines:
1. Mark at the top of the form the primary data source as patient, caregiver, or patient and caregiver in equal proportion.
2. The response to each item should refer to a period encompassing the prior week, including the day on which the information is collected.
3. All items must have an integer rating (no half points, no missing scores). In the event that an item does not apply or cannot be rated (e.g., amputee who cannot walk), the item is marked ""UR"" for Unable to Rate.
4. The answers should reflect the usual level of function, and words such as “usually,” “generally,” “most of the time” can be used with patients.
5. Each question has a text for you to read (Instructions to patients/caregiver). After that statement, you can elaborate and probe based on the target symptoms outlined in the Instructions to examiner. You should NOT READ the RATING OPTIONS to the patient/caregiver because these are written in medical terminology. From the interview and probing, you will use your medical judgment to arrive at the best response.
6. Patients may have co-morbidities and other medical conditions that can affect their function. You and the patient must rate the problem as it exists and do not attempt to separate elements due to Parkinson’s disease from other conditions.
",
				DefaultOpen = false
			},
		

			new OptionsItem
			{
				InstructionsForThePatient = "I am going to ask you six questions about behaviors that you may or may not experience. Some questions concern common problems and some concern uncommon ones. If you have a problem in one of the areas, please choose the best response that describes how you have felt MOST OF THE TIME during the PAST WEEK. If you are not bothered by a problem, you can simply respond NO. I am trying to be thorough, so I may ask questions that have nothing to do with you.",
				Options = new List<string> { "Patient", "Caregiver", "Patient and Caregiver in Equal Proportion" },
				Label = "Primary source of information:"
			},

			new ComplexOptionsItem
			{
				Label = "1.1 COGNITIVE IMPAIRMENT",
				InstructionsForTheExaminer = "Consider all types of altered level of cognitive function including cognitive slowing, impaired reasoning, memory loss, deficits in attention and orientation. Rate their impact on activities of daily living as perceived by the patient and/or caregiver.",
				InstructionsForThePatient = "Over the past week have you had problems remembering things, following conversations, paying attention, thinking clearly, or finding your way around the house or in town? [If yes, examiner asks patient or caregiver to elaborate and probes for information.]",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "No cognitive impairment.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Impairment appreciated by patient or caregiver with no concrete interference with the patient’s ability to carry out normal activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Clinically evident cognitive dysfunction, but only minimal interference with the patient’s ability to carry out normal activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Cognitive deficits interfere with but do not preclude the patient’s ability to carry out normal activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Cognitive dysfunction precludes the patient’s ability to carry out normal activities and social interactions.",
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "1.2 HALLUCINATIONS AND PSYCHOSIS",
				InstructionsForTheExaminer = "Consider both illusions (misinterpretations of real stimuli) and hallucinations (spontaneous false sensations). Consider all major sensory domains (visual, auditory, tactile, olfactory, and gustatory). Determine presence of unformed (for example sense of presence or fleeting false impressions) as well as formed (fully developed and detailed) sensations. Rate the patient’s insight into hallucinations and identify delusions and psychotic thinking.",
				InstructionsForThePatient = "Over the past week have you seen, heard, smelled, or felt things that were not really there? [If yes, examiner asks patient or caregiver to elaborate and probes for information.]",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "No hallucinations or psychotic behavior.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Illusions or non-formed hallucinations, but patient recognizes them without loss of insight.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Formed hallucinations independent of environmental stimuli. No loss of insight.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Formed hallucinations with loss of insight.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Patient has delusions or paranoia.",
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "1.3 DEPRESSED MOOD",
				InstructionsForTheExaminer = "Consider low mood, sadness, hopelessness, feelings of emptiness, or loss of enjoyment. Determine their presence and duration over the past week and rate their interference with the patient’s ability to carry out daily routines and engage in social interactions.",
				InstructionsForThePatient = "Over the past week have you felt low, sad, hopeless, or unable to enjoy things? If yes, was this feeling for longer than one day at a time? Did it make it difficult for you to carry out your usual activities or to be with people? [If yes, examiner asks the patient or caregiver to elaborate and probes for information.]",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No depressed mood.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "Episodes of depressed mood that are not sustained for more than one day at a time. No interference with the patient’s ability to carry out normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Depressed mood that is sustained over days, but without interference with normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Depressed mood that interferes with, but does not preclude the patient’s ability to carry out normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "Depressed mood precludes the patient’s ability to carry out normal activities and social interactions.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.4 ANXIOUS MOOD",
				InstructionsForTheExaminer = "Determine nervous, tense, worried, or anxious feelings (including panic attacks) over the past week and rate their duration and interference with the patient’s ability to carry out daily routines and engage in social interactions.",
				InstructionsForThePatient = "Over the past week have you felt nervous, worried, or tense? If yes, was this feeling for longer than one day at a time? Did it make it difficult for you to follow your usual activities or to be with other people? [If yes, examiner asks the patient or caregiver to elaborate and probes for information.]",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No anxious feelings.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "Anxious feelings present but not sustained for more than one day at a time. No interference with the patient’s ability to carry out normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Anxious feelings are sustained over more than one day at a time, but without interference with the patient’s ability to carry out normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Anxious feelings interfere with, but do not preclude, the patient’s ability to carry out normal activities and social interactions.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "Anxious feelings preclude the patient’s ability to carry out normal activities and social interactions.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.5 APATHY",
				InstructionsForTheExaminer = "Consider level of spontaneous activity, assertiveness, motivation, and initiative and rate the impact of reduced levels on performance of daily routines and social interactions. Here the examiner should attempt to distinguish between apathy and similar symptoms that are best explained by depression.",
				InstructionsForThePatient = "Over the past week, have you felt indifferent to doing activities or being with people? [If yes, examiner asks the patient or caregiver to elaborate and probes for information.]",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "No apathy.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Apathy appreciated by patient and/or caregiver, but no interference with daily activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Apathy interferes with isolated activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Apathy interferes with most activities and social interactions.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Passive and withdrawn, complete loss of initiative.",
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "1.6 FEATURES OF DOPAMINE DYSREGULATION SYNDROME",
				InstructionsForTheExaminer = "Consider involvement in a variety of activities including atypical or excessive gambling (e.g. casinos or lottery tickets), atypical or excessive sexual drive or interests (e.g., unusual interest in pornography, masturbation, sexual demands on partner), other repetitive activities (e.g. hobbies, dismantling objects, sorting or organizing), or taking extra non-prescribed medication for non-physical reasons (i.e., addictive behavior). Rate the impact of such abnormal activities/behaviors on the patient’s personal life and on his/her family and social relations (including need to borrow money or other financial difficulties like withdrawal of credit cards, major family conflicts, lost time from work, or missed meals or sleep because of the activity).",
				InstructionsForThePatient = "Over the past week, have you had unusually strong urges that are hard to control? Do you feel driven to do or think about something and find it hard to stop? [Give patient examples such as gambling, cleaning, using the computer, taking extra medicine, obsessing about food or sex, all depending on the patient.]",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No problems present.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "Problems are present but usually do not cause any difficulties for the patient or family/caregiver.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Problems are present and usually cause a few difficulties in the patient’s personal and family life.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Problems are present and usually cause a lot of difficulties in the patient’s personal and family life.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "Problems are present and preclude the patient’s ability to carry out normal activities or social interactions or to maintain previous standards in personal and family life.",
						},
					}
			},


			new OptionsItem
			{
				InstructionsForThePatient = "This questionnaire will ask you about your experiences of daily living.\r\nThere are 20 questions. We are trying to be thorough, and some of these questions may therefore not apply to you now or ever. If you do not have the problem, simply mark 0 for NO.\r\nPlease read each one carefully and read all answers before selecting the one that best applies to you.\r\nWe are interested in your average or usual function over the past week including today. Some patients can do things better at one time of the day than at others. However, only one answer is allowed for each question, so please mark the answer that best describes what you can do most of the time.\r\nYou may have other medical conditions besides Parkinson’s disease. Do not worry about separating Parkinson’s disease from other conditions. Just answer the question with your best response.\r\nUse only 0, 1, 2, 3, 4 for answers, nothing else. Do not leave any blanks.\r\nYour doctor or nurse can review the questions with you, but this questionnaire is for patients to complete, either alone or with their caregivers.",
				Label = "Who is filling out this questionnaire (check the best answer):",
				Options = new List<string> { "Patient", "Caregiver", "Patient and Caregiver in Equal Proportion" }
			},


			new ComplexOptionsItem
			{
				Label = "1.7 SLEEP PROBLEMS",
				InstructionsForThePatient = "Over the past week, have you had trouble going to sleep at night or staying asleep through the night? Consider how rested you felt after waking up in the morning.",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "No problems.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Sleep problems are present but usually do not cause trouble getting a full night of sleep.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Sleep problems usually cause some difficulties getting a full night of sleep.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Sleep problems cause a lot of difficulties getting a full night of sleep, but I still usually sleep for more than half the night.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "I usually do not sleep for most of the night.",
							},
						}
			},
			new ComplexOptionsItem
			{
				Label = "1.8 DAYTIME SLEEPINESS",
				InstructionsForThePatient = "Over the past week, have you had trouble staying awake during the daytime?",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No daytime sleepiness.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "Daytime sleepiness occurs, but I can resist and I stay awake.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Sometimes I fall asleep when alone and relaxing. For example, while reading or watching TV.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "I sometimes fall asleep when I should not. For example, while eating or talking with other people.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "I often fall asleep when I should not. For example, while eating or talking with other people.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.9 PAIN AND OTHER SENSATIONS",
				InstructionsForThePatient = "Over the past week, have you had uncomfortable feelings in your body like pain, aches, tingling, or cramps?",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No uncomfortable feelings.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "I have these feelings. However, I can do things and be with other people without difficulty.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "These feelings cause some problems when I do things or am with other people.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "These feelings cause a lot of problems, but they do not stop me from doing things or being with other people.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "These feelings stop me from doing things or being with other people.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.10 URINARY PROBLEMS",
				InstructionsForThePatient = "Over the past week, have you had trouble with urine control? For example, an urgent need to urinate, a need to urinate too often, or urine accidents?",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No urine control problems.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "I need to urinate often or urgently. However, these problems do not cause difficulties with my daily activities.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Urine problems cause some difficulties with my daily activities. However, I do not have urine accidents.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Urine problems cause a lot of difficulties with my daily activities, including urine accidents.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "I cannot control my urine and use a protective garment or have a bladder tube.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.11 CONSTIPATION PROBLEMS",
				InstructionsForThePatient = "Over the past week have you had constipation troubles that cause you difficulty moving your bowels?",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No constipation.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "I have been constipated. I use extra effort to move my bowels. However, this problem does not disturb my activities or my being comfortable.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Constipation causes me to have some troubles doing things or being comfortable.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Constipation causes me to have a lot of trouble doing things or being comfortable. However, it does not stop me from doing anything.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "I usually need physical help from someone else to empty my bowels.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.12 LIGHT HEADEDNESS ON STANDING",
				InstructionsForThePatient = "Over the past week, have you felt faint, dizzy, or foggy when you stand up after sitting or lying down?",
				Options = new List<ComplexOptionsItem.Option>
					{
						new ComplexOptionsItem.Option
						{
							Value = 0,
							Name = "Normal",
							Description = "No dizzy or foggy feelings.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 1,
							Name = "Slight",
							Description = "Dizzy or foggy feelings occur. However, they do not cause me troubles doing things.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 2,
							Name = "Mild",
							Description = "Dizzy or foggy feelings cause me to hold on to something, but I do not need to sit or lie back down.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 3,
							Name = "Moderate",
							Description = "Dizzy or foggy feelings cause me to sit or lie down to avoid fainting or falling.",
						},
						new ComplexOptionsItem.Option
						{
							Value = 4,
							Name = "Severe",
							Description = "Dizzy or foggy feelings cause me to fall or faint.",
						},
					}
			},
			new ComplexOptionsItem
			{
				Label = "1.13 FATIGUE",
				InstructionsForThePatient = "Over the past week, have you usually felt fatigued? This feeling is not part of being sleepy or sad.",
				Options = new List<ComplexOptionsItem.Option>
						{
							new ComplexOptionsItem.Option
							{
								Value = 0,
								Name = "Normal",
								Description = "No fatigue.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 1,
								Name = "Slight",
								Description = "Fatigue occurs. However, it does not cause me troubles doing things or being with people.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 2,
								Name = "Mild",
								Description = "Fatigue causes me some troubles doing things or being with people.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 3,
								Name = "Moderate",
								Description = "Fatigue causes me a lot of troubles doing things or being with people. However, it does not stop me from doing anything.",
							},
							new ComplexOptionsItem.Option
							{
								Value = 4,
								Name = "Severe",
								Description = "Fatigue stops me from doing things or being with people.",
							},
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
