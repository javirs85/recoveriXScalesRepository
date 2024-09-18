

using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class UPDRSIV : ScaleBase
{
    public UPDRSIV()
    {
		
	}

	public override void Init()
	{
		Id = ScalesIDs.UPDRSIV;
		Name = "Unified Parkinson's Disease Rating Scale - Section IV";
		ShortName = "UPDRS-IV";
		AreaOfStudy = "Complications therapy";

		DetailsHeaders = new List<string> { "Points" };
	}
	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(overview);
		Items.Add(TimeWithDysk);
		Items.Add(TotalHoursAwake);
		Items.Add(TotaHoursWithDisk);
		Items.Add(DiskAutoUpdate);
		Items.Add(FunctionalImpact);
		Items.Add(TimeSpentOff);
		Items.Add(TotalHoursAwake_off);
		Items.Add(TotalHoursOff);
		Items.Add(AutoOffTime);
		Items.Add(ImpactOfFluctuations);
		Items.Add(ComplexityOfMotorFluctuations);
		Items.Add(PainfulOffState);
		Items.Add(closing);
	}

	InfoItem overview { get; set; } = new InfoItem
	{
		Label = "Overview",
		Text = @"
# Overview and Instructions
In this section, the rater uses historical and objective information to assess two motor complications, dyskinesias and motor fluctuations that include OFF-state dystonia. Use all information from patient, caregiver, and the examination to answer the six questions that summarize function over the past week including today. As in the other sections, rate using only integers (no half points allowed) and leave no missing ratings. If the item cannot be rated, place ""**UR**"" for Unable to Rate. You will need to choose some answers based on percentages, and therefore you will need to establish how many hours the patient is generally awake and use this figure as the denominator for “OFF” time and dyskinesias. For “OFF dystonia”, the total “OFF” time will be the denominator. Operational definitions for examiner’s use.

Dyskinesias: Involuntary random movements:
Words that patients often recognize for dyskinesias include “irregular jerking”, “wiggling”, “twitching.” **It is essential to stress to the patient the difference between dyskinesias and tremor, a common error when patients are assessing dyskinesias.**

Dystonia: Contorted posture, often with a twisting component:
Words that patients often recognize for dystonia include “spasms”, “cramps”, “posture.”

Motor fluctuation: Variable response to medication:
Words that patients often recognize for motor fluctuation include “wearing out”, “wearing off”, “roller-coaster effect”, “on-off”, “uneven medication effects.”

- **OFF**: Typical functional state when patients have a poor response in spite of taking mediation or the typical functional response when patients are on NO treatment for parkinsonism. Words that patients often recognize include “low
time”, “bad time”, “shaking time”, “slow time”, “time when my medications don’t work.”
- **ON**: Typical functional state when patients are receiving medication and have a good response:
Words that patients often recognize include “good time”, “walking time”, “time when my medications work.”
",
		DefaultOpen = false
	};
	ComplexOptionsItem TimeWithDysk { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "TimeDisk",
        Label = "Time Spent with Dyskinesias",
		InstructionsForTheExaminer = "Determine the hours in the usual waking day and then the hours of dyskinesias. Calculate the percentage. If the patient has dyskinesias in the office, you can point them out as a reference to ensure that patients and caregivers understand what they are rating. You may also use your own acting skills to enact the dyskinetic movements you have seen in the patient before or show them dyskinetic movements typical of other patients. Exclude from this question early morning and nighttime painful dystonia.",
		InstructionsForThePatient = "Over the past week, how many hours do you usually sleep on a daily basis, including nighttime sleep and daytime napping? Alright, if you sleep ___ hrs, you are awake ____ hrs. Out of those awake hours, how many hours in total do you have wiggling, twitching, or jerking movements? Do not count the times when you have tremor, which is a regular back and forth shaking or times when you have painful foot cramps or spasms in the early morning or at nighttime. I will ask about those later. Concentrate only on these types of wiggling, jerking, and irregular movements. Add up all the time during the waking day when these usually occur. How many hours ____ (use this number for your calculations).",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description="No dyskinesias" },
					new Option { Value = 1, Name = "Slight", Description = "≤ 25% of waking day" },
					new Option { Value = 2, Name = "Mild", Description = "26 - 50% of waking day" },
					new Option { Value = 3, Name = "Moderate", Description = "51 - 75% of waking day" },
					new Option { Value = 4, Name = "Severe", Description = "> 75% of waking day" }
				}
	};
	IntItem TotalHoursAwake { get; set; } = new IntItem
    {
        JsonCode = "AwakeH",
        Label = "Total Hours Awake:"
	};
	IntItem TotaHoursWithDisk { get; set; } = new IntItem
    {
        JsonCode = "DiskH",
        Label = "Total Hours with Dyskinesia:"
	};
	IntItem DiskAutoUpdate { get; set; } = new IntItem
	{
		JsonCode = "AutoDisk",
		Label = "AUTOUPDATE [Not required]: % Dyskinesia = ((Total Hours with Dyskinesia/Total Hours Awake)*100):",
	};
	ComplexOptionsItem FunctionalImpact { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "Impact",
        Label = "Functional Impact of Dyskinesias",
		InstructionsForTheExaminer = "Determine the degree to which dyskinesias impact on the patient’s daily function in terms of activities and social interactions. Use the patient’s and caregiver’s response to your question and your own observations during the office visit to arrive at the best answer.",
		InstructionsForThePatient = "Over the past week, did you usually have trouble doing things or being with people when these jerking movements occurred? Did they stop you from doing things or from being with people?",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No dyskinesias or no impact by dyskinesias on activities or social interactions." },
					new Option { Value = 1, Name = "Slight", Description = "Dyskinesias impact on a few activities, but the patient usually performs all activities and participates in all social interactions during dyskinetic periods." },
					new Option { Value = 2, Name = "Mild", Description = "Dyskinesias impact on many activities, but the patient usually performs all activities and participates in all social interactions during dyskinetic periods." },
					new Option { Value = 3, Name = "Moderate", Description = "Dyskinesias impact on activities to the point that the patient usually does not perform some activities or does not usually participate in some social activities during dyskinetic episodes." },
					new Option { Value = 4, Name = "Severe", Description = "Dyskinesias impact on function to the point that the patient usually does not perform most activities or participate in most social interactions during dyskinetic episodes." }
				}
	};
	ComplexOptionsItem TimeSpentOff { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "TimeOff",
        Label = "Time Spent in the OFF State",
		InstructionsForTheExaminer = "Use the number of waking hours derived from 4.1 and determine the hours spent in the “OFF” state. Calculate the percentage.",
		InstructionsForThePatient = "Some patients with Parkinson’s disease have a good effect from their medications throughout their awake hours and we call that “ON” time. Other patients take their medications but still have some hours of low time, bad time, slow time, or shaking time. Doctors call these low periods “OFF” time. Over the past week, you told me before that you are generally awake ____ hrs each day. Out of these awake hours, how many hours in total do you usually have this type of low level or OFF function? ____ (use this number for your calculations).",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No OFF time." },
					new Option { Value = 1, Name = "Slight", Description = "≤ 25% of waking day." },
					new Option { Value = 2, Name = "Mild", Description = "26 - 50% of waking day." },
					new Option { Value = 3, Name = "Moderate", Description = "51 - 75% of waking day." },
					new Option { Value = 4, Name = "Severe", Description = "> 75% of waking day." }
				}
	};
	IntItem TotalHoursAwake_off { get; set; } = new IntItem
    {
        JsonCode = "AwakeHOff",
        Label = "Total Hours Awake:"
	};
	IntItem TotalHoursOff { get; set; } = new IntItem
    {
        JsonCode = "HoursOff",
        Label = "Total Hours OFF:"
	};
	IntItem AutoOffTime { get; set; } = new IntItem
	{
		JsonCode = "AutoOff",
		Label = "AUTOUPDATE [Not required]: % Dyskinesia = ((Total Hours OFF/Total Hours Awake)*100):",
	};
	ComplexOptionsItem ImpactOfFluctuations { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "FluctImpact",
        Label = "Functional Impact of Fluctuations",
		InstructionsForTheExaminer = "Determine the degree to which motor fluctuations impact on the patient’s daily function in terms of activities and social interactions. This question concentrates on the difference between the ON state and the OFF state.",
		InstructionsForThePatient = "Think about when those low or “OFF” periods have occurred over the past week. Do you usually have more problems doing things or being with people than compared to the rest of the day when you feel your medications working? Are there some things you usually do during a good period that you have trouble with or stop doing during a low period?",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No fluctuations or no impact by fluctuations on performance of activities or social interactions." },
					new Option { Value = 1, Name = "Slight", Description = "Fluctuations impact on a few activities, but during OFF, the patient usually performs all activities and participates in all social interactions that typically occur during the ON state." },
					new Option { Value = 2, Name = "Mild", Description = "Fluctuations impact many activities, but during OFF, the patient still usually performs all activities and participates in all social interactions that typically occur during the ON state." },
					new Option { Value = 3, Name = "Moderate", Description = "Fluctuations impact on the performance of activities during OFF to the point that the patient usually does not perform some activities or participate in some social interactions that are performed during ON periods." },
					new Option { Value = 4, Name = "Severe", Description = "Fluctuations impact on function to the point that, during OFF, the patient usually does not perform most activities or participate in most social interactions that are performed during ON periods."}
				}
	};
	ComplexOptionsItem ComplexityOfMotorFluctuations { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "FluctComplexity",
        Label = "Complexity of Motor Fluctuations",
		InstructionsForTheExaminer = "Determine the usual predictability of OFF function whether due to dose, time of day, food intake, or other factors. Use the information provided by the patients and caregivers and supplement with your own observations.",
		InstructionsForThePatient = "For some patients, the low or “OFF” periods happen at certain times during the day or when they do activities like eating or exercising. Over the past week, do you usually know when your low periods will occur? In other words, do your low periods always come at a certain time? Do they mostly come at a certain time? Do they only sometimes come at a certain time? Are your low periods totally unpredictable?",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No motor fluctuations." },
					new Option { Value = 1, Name = "Slight", Description = "OFF times are predictable all or almost all of the time (> 75%)." },
					new Option { Value = 2, Name = "Mild", Description = "OFF times are predictable most of the time (51-75%)." },
					new Option { Value = 3, Name = "Moderate", Description = "OFF times are predictable some of the time (26-50%)." },
					new Option { Value = 4, Name = "Severe", Description = "OFF episodes are rarely predictable (≤ 25%)." }
				}
	};
	ComplexOptionsItem PainfulOffState { get; set; } = new ComplexOptionsItem
    {
        JsonCode = "PainfulPerc",
        Label = "Painful OFF-State Dystonia",
		InstructionsForTheExaminer = "For patients who have motor fluctuations, determine what proportion of the OFF episodes usually includes painful dystonia? You have already determined the number of hours of “OFF” time (4.3). Of these hours, determine how many are associated with dystonia and calculate the percentage. If there is no OFF time, mark 0.",
		InstructionsForThePatient = "In one of the questions I asked earlier, you said you generally have ____ hours of low or “OFF” time when your Parkinson's disease is under poor control. During these low or “OFF” periods, do you usually have painful cramps or spasms? Out of the total ____ hrs of this low time, if you add up all the time in a day when these painful cramps come, how many hours would this make?",
		Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No dystonia OR NO OFF TIME" },
					new Option { Value = 1, Name = "Slight", Description = "≤ 25% of time in OFF state" },
					new Option { Value = 2, Name = "Mild", Description = "26-50% of time in OFF state" },
					new Option { Value = 3, Name = "Moderate", Description = "51-75% of time in OFF state" },
					new Option { Value = 4, Name = "Severe", Description = "> 75% of time in OFF state" }
				}
	};
	InfoItem closing { get; set; } = new InfoItem
	{
		Label = "Summary statement to patient: READ TO PATIENT",
		Text = @"
This completes my rating of your Parkinson’s disease. I know the questions and tasks have taken several minutes, but I wanted to be complete and cover all possibilities. In doing so, I may have asked about problems you do not even have, and I may have mentioned problems that you may never develop at all. Not all patients develop all these problems, but because they can occur, it is important to ask all the questions to every patient. Thank you for your time and attention in completing this scale with me.",
		DefaultOpen = true
	};


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
		if(TotalHoursAwake_off.Value != 0)
			AutoOffTime.Value = (int)Math.Round((double)(((float)TotalHoursOff.Value / (float)TotalHoursAwake_off.Value)) * 100);

		if(TotalHoursAwake.Value != 0)
			DiskAutoUpdate.Value = (int)Math.Round((double)(((float)TotaHoursWithDisk.Value / (float)TotalHoursAwake.Value)) * 100);
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
