

using System.IO;
using System.Text.Json.Serialization;
using static CompanionAppShared.Scales.ComplexOptionsItem;

namespace CompanionAppShared.Scales;


public class UPDRSIII : ScaleBase
{
	public UPDRSIII()
	{
		
	}

	public override void Init()
	{
		Id = ScalesIDs.UPDRSIII;
		Name = "Unified Parkinson's Disease Rating Scale - Section III";
		ShortName = "UPDRS-III";
		AreaOfStudy = "Motor examination";

		DetailsHeaders = new List<string> { "Points" };

		Items = new List<ScaleItem>
		{
			new InfoItem
			{
				Label = "Overview",
				Text = @"
# Overview
This portion of the scale assesses the motor signs of PD. In administering Part III of the MDS-UPDRS
the examiner should comply with the following guidelines:

At the top of the form, mark whether the patient is on medication for treating the symptoms of Parkinson's disease and, if on levodopa, the time since the last dose.

Also, if the patient is receiving medication for treating the symptoms of Parkinson’s disease, mark the patient’s clinical state using the following definitions:
 - **ON** is the typical functional state when patients are receiving medication and have a good response.
 - **OFF** is the typical functional state when patients have a poor response in spite of taking medications.

The investigator should “rate what you see.” Admittedly, concurrent medical problems such as stroke, paralysis, arthritis, contracture, and orthopedic problems such as hip or knee replacement and scoliosis may interfere with individual items in the motor examination. In situations where it is absolutely impossible to test (e.g., amputations, plegia, limb in a cast), use the notation “UR” for Unable to Rate. Otherwise, rate the performance of each task as the patient performs in the context of co-morbidities.

All items must have an integer rating (no half points, no missing ratings).

Specific instructions are provided for the testing of each item. These should be followed in all instances. The investigator demonstrates while describing tasks the patient is to perform and rates function immediately thereafter. For Global Spontaneous Movement and Rest Tremor items (3.14 and 3.17), these items have been placed purposefully at the end of the scale because clinical information pertinent to the score will be obtained throughout the entire examination.

At the end of the rating, indicate if dyskinesia (chorea or dystonia) was present at the time of the examination, and if so, whether these movements interfered with the motor examination.
",
				DefaultOpen = false
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.1",
                Label = "3.1 SPEECH",
				InstructionsForTheExaminer = "Listen to the patient’s free-flowing speech and engage in conversation if necessary. Suggested topics: ask about the patient’s work, hobbies, exercise, or how he got to the doctor’s office. Evaluate volume, modulation (prosody), and clarity, including slurring, palilalia (repetition of syllables), and tachyphemia (rapid speech, running syllables together).",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No speech problems." },
					new Option { Value = 1, Name = "Slight", Description = "Loss of modulation, diction, or volume, but still all words easy to understand." },
					new Option { Value = 2, Name = "Mild", Description = "Loss of modulation, diction, or volume, with a few words unclear, but the overall sentences easy to follow." },
					new Option { Value = 3, Name = "Moderate", Description = "Speech is difficult to understand to the point that some, but not most, sentences are poorly understood." },
					new Option { Value = 4, Name = "Severe", Description = "Most speech is difficult to understand or unintelligible." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.2",
                Label = "3.2 FACIAL EXPRESSION",
				InstructionsForTheExaminer = "Observe the patient sitting at rest for 10 seconds, without talking and also while talking. Observe eye-blink frequency, masked facies or loss of facial expression, spontaneous smiling, and parting of lips.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "Normal facial expression." },
					new Option { Value = 1, Name = "Slight", Description = "Minimal masked facies manifested only by decreased frequency of blinking." },
					new Option { Value = 2, Name = "Mild", Description = "In addition to decreased eye-blink frequency, masked facies present in the lower face as well, namely fewer movements around the mouth, such as less spontaneous smiling, but lips not parted." },
					new Option { Value = 3, Name = "Moderate", Description = "Masked facies with lips parted some of the time when the mouth is at rest." },
					new Option { Value = 4, Name = "Severe", Description = "Masked facies with lips parted most of the time when the mouth is at rest." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.3",
                Label = "3.3 RIGIDITY",
				InstructionsForTheExaminer = "Rigidity is judged on slow passive movement of major joints with the patient in a relaxed position and the examiner manipulating the limbs and neck. First, test without an activation maneuver. Test and rate neck and each limb separately. For arms, test the wrist and elbow joints simultaneously. For legs, test the hip and knee joints simultaneously. If no rigidity is detected, use an activation maneuver such as tapping fingers, fist opening/closing, or heel tapping in a limb not being tested. Explain to the patient to go as limp as possible as you test for rigidity.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No rigidity." },
					new Option { Value = 1, Name = "Slight", Description = "Rigidity only detected with activation maneuver." },
					new Option { Value = 2, Name = "Mild", Description = "Rigidity detected without the activation maneuver, but full range of motion is easily achieved." },
					new Option { Value = 3, Name = "Moderate", Description = "Rigidity detected without the activation maneuver; full range of motion is achieved with effort." },
					new Option { Value = 4, Name = "Severe", Description = "Rigidity detected without the activation maneuver and full range of motion not achieved." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.4",
                Label = "3.4 FINGER TAPPING",
				InstructionsForTheExaminer = "Each hand is tested separately. Demonstrate the task, but do not continue to perform the task while the patient is being tested. Instruct the patient to tap the index finger on the thumb 10 times as quickly AND as big as possible. Rate each side separately, evaluating speed, amplitude, hesitations, halts, and decrementing amplitude.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Any of the following: a) the regular rhythm is broken with one or two interruptions or hesitations of the tapping movement; b) slight slowing; c) the amplitude decrements near the end of the 10 taps." },
					new Option { Value = 2, Name = "Mild", Description = "Any of the following: a) 3 to 5 interruptions during tapping; b) mild slowing; c) the amplitude decrements midway in the 10-tap sequence." },
					new Option { Value = 3, Name = "Moderate", Description = "Any of the following: a) more than 5 interruptions during tapping or at least one longer arrest (freeze) in ongoing movement; b) moderate slowing; c) the amplitude decrements starting after the 1st tap." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot or can only barely perform the task because of slowing, interruptions, or decrements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.5",
                Label = "3.5 HAND MOVEMENTS",
				InstructionsForTheExaminer = "Test each hand separately. Demonstrate the task, but do not continue to perform the task while the patient is being tested. Instruct the patient to make a tight fist with the arm bent at the elbow so that the palm faces the examiner. Have the patient open the hand 10 times as fully AND as quickly as possible. If the patient fails to make a tight fist or to open the hand fully, remind him/her to do so. Rate each side separately, evaluating speed, amplitude, hesitations, halts, and decrementing amplitude.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Any of the following: a) the regular rhythm is broken with one or two interruptions or hesitations of the movement; b) slight slowing; c) the amplitude decrements near the end of the task." },
					new Option { Value = 2, Name = "Mild", Description = "Any of the following: a) 3 to 5 interruptions during the movements; b) mild slowing; c) the amplitude decrements midway in the task." },
					new Option { Value = 3, Name = "Moderate", Description = "Any of the following: a) more than 5 interruptions during the movement or at least one longer arrest (freeze) in ongoing movement; b) moderate slowing; c) the amplitude decrements starting after the 1st open-and-close sequence." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot or can only barely perform the task because of slowing, interruptions, or decrements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.6",
                Label = "3.6 PRONATION-SUPINATION MOVEMENTS OF HANDS",
				InstructionsForTheExaminer = "Test each hand separately. Demonstrate the task, but do not continue to perform the task while the patient is being tested. Instruct the patient to extend the arm out in front of his/her body with the palms down, and then to turn the palm up and down alternately 10 times as fast and as fully as possible. Rate each side separately, evaluating speed, amplitude, hesitations, halts, and decrementing amplitude.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Any of the following: a) the regular rhythm is broken with one or two interruptions or hesitations of the movement; b) slight slowing; c) the amplitude decrements near the end of the sequence." },
					new Option { Value = 2, Name = "Mild", Description = "Any of the following: a) 3 to 5 interruptions during the movements; b) mild slowing; c) the amplitude decrements midway in the sequence." },
					new Option { Value = 3, Name = "Moderate", Description = "Any of the following: a) more than 5 interruptions during the movement or at least one longer arrest (freeze) in ongoing movement; b) moderate slowing; c) the amplitude decrements starting after the 1st supination-pronation sequence." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot or can only barely perform the task because of slowing, interruptions, or decrements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.7",
                Label = "3.7 TOE TAPPING",
				InstructionsForTheExaminer = "Have the patient sit in a straight-backed chair with arms, both feet on the floor. Test each foot separately. Demonstrate the task, but do not continue to perform the task while the patient is being tested. Instruct the patient to place the heel on the ground in a comfortable position and then tap the toes 10 times as big and as fast as possible. Rate each side separately, evaluating speed, amplitude, hesitations, halts, and decrementing amplitude.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Any of the following: a) the regular rhythm is broken with one or two interruptions or hesitations of the tapping movement; b) slight slowing; c) amplitude decrements near the end of the ten taps." },
					new Option { Value = 2, Name = "Mild", Description = "Any of the following: a) 3 to 5 interruptions during the tapping movements; b) mild slowing; c) amplitude decrements midway in the task." },
					new Option { Value = 3, Name = "Moderate", Description = "Any of the following: a) more than 5 interruptions during the tapping movements or at least one longer arrest (freeze) in ongoing movement; b) moderate slowing; c) amplitude decrements after the 1st tap." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot or can only barely perform the task because of slowing, interruptions or decrements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.8",
                Label = "3.8 LEG AGILITY",
				InstructionsForTheExaminer = "Have the patient sit in a straight-backed chair with arms. The patient should have both feet comfortably on the floor. Test each leg separately. Demonstrate the task, but do not continue to perform the task while the patient is being tested. Instruct the patient to place the foot on the ground in a comfortable position and then raise and stomp the foot on the ground 10 times as high and as fast as possible. Rate each side separately, evaluating speed, amplitude, hesitations, halts and decrementing amplitude.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Any of the following: a) the regular rhythm is broken with one or two interruptions or hesitations of the movement; b) slight slowing; c) amplitude decrements near the end of the task." },
					new Option { Value = 2, Name = "Mild", Description = "Any of the following: a) 3 to 5 interruptions during the movements; b) mild slowness; c) amplitude decrements midway in the task." },
					new Option { Value = 3, Name = "Moderate", Description = "Any of the following: a) more than 5 interruptions during the movement or at least one longer arrest (freeze) in ongoing movement; b) moderate slowing in speed; c) amplitude decrements after the 1st tap." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot or can only barely perform the task because of slowing, interruptions, or decrements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.9",
                Label = "3.9 ARISING FROM CHAIR",
				InstructionsForTheExaminer = "Have the patient sit in a straight-backed chair with arms, with both feet on the floor and sitting back in the chair (if the patient is not too short). Ask the patient to cross his/her arms across the chest and then to stand up. If the patient is not successful, repeat this attempt up to a maximum of two more times. If still unsuccessful, allow the patient to move forward in the chair to arise with arms folded across the chest. Allow only one attempt in this situation. If unsuccessful, allow the patient to push off using his/her hands on the arms of the chair. Allow a maximum of three trials of pushing off. If still not successful, assist the patient to arise. After the patient stands up, observe the posture for item 3.13.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems. Able to arise quickly without hesitation." },
					new Option { Value = 1, Name = "Slight", Description = "Arising is slower than normal; or may need more than one attempt; or may need to move forward in the chair to arise. No need to use the arms of the chair." },
					new Option { Value = 2, Name = "Mild", Description = "Pushes self up from the arms of the chair without difficulty." },
					new Option { Value = 3, Name = "Moderate", Description = "Needs to push off, but tends to fall back; or may have to try more than one time using the arms of the chair, but can get up without help." },
					new Option { Value = 4, Name = "Severe", Description = "Unable to arise without help." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.10",
                Label = "3.10 GAIT",
				InstructionsForTheExaminer = "Testing gait is best performed by having the patient walking away from and towards the examiner so that both right and left sides of the body can be easily observed simultaneously. The patient should walk at least 10 meters (30 feet), then turn around and return to the examiner. This item measures multiple behaviors: stride amplitude, stride speed, height of foot lift, heel strike during walking, turning, and arm swing, but not freezing. Assess also for 'freezing of gait' (next item 3.11) while patient is walking. Observe posture for item 3.13.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Independent walking with minor gait impairment." },
					new Option { Value = 2, Name = "Mild", Description = "Independent walking but with substantial gait impairment." },
					new Option { Value = 3, Name = "Moderate", Description = "Requires an assistance device for safe walking (walking stick, walker) but not a person." },
					new Option { Value = 4, Name = "Severe", Description = "Cannot walk at all or only with another person’s assistance." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.11",
                Label = "3.11 FREEZING OF GAIT",
				InstructionsForTheExaminer = "While assessing gait, also assess for the presence of any gait freezing episodes. Observe for start hesitation and stuttering movements especially when turning and reaching the end of the task. To the extent that safety permits, patients may NOT use sensory tricks during the assessment.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No freezing." },
					new Option { Value = 1, Name = "Slight", Description = "Freezes on starting, turning, or walking through doorway with a single halt during any of these events, but then continues smoothly without freezing during straight walking." },
					new Option { Value = 2, Name = "Mild", Description = "Freezes on starting, turning, or walking through doorway with more than one halt during any of these activities, but continues smoothly without freezing during straight walking." },
					new Option { Value = 3, Name = "Moderate", Description = "Freezes once during straight walking." },
					new Option { Value = 4, Name = "Severe", Description = "Freezes multiple times during straight walking." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.12",
                Label = "3.12 POSTURAL STABILITY",
				InstructionsForTheExaminer = "The test examines the response to sudden body displacement produced by a quick, forceful pull on the shoulders while the patient is standing erect with eyes open and feet comfortably apart and parallel to each other. Test retropulsion. Stand behind the patient and instruct the patient on what is about to happen. Explain that s/he is allowed to take a step backwards to avoid falling. There should be a solid wall behind the examiner, at least 1-2 meters away to allow for the observation of the number of retropulsive steps. The first pull is an instructional demonstration and is purposely milder and not rated. The second time the shoulders are pulled briskly and forcefully towards the examiner with enough force to displace the center of gravity so that patient MUST take a step backwards. The examiner needs to be ready to catch the patient, but must stand sufficiently back so as to allow enough room for the patient to take several steps to recover independently. Do not allow the patient to flex the body abnormally forward in anticipation of the pull. Observe for the number of steps backwards or falling. Up to and including two steps for recovery is considered normal, so abnormal ratings begin with three steps. If the patient fails to understand the test, the examiner can repeat the test so that the rating is based on an assessment that the examiner feels reflects the patient’s limitations rather than misunderstanding or lack of preparedness. Observe standing posture for item 3.13.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems. Recovers with one or two steps." },
					new Option { Value = 1, Name = "Slight", Description = "3-5 steps, but subject recovers unaided." },
					new Option { Value = 2, Name = "Mild", Description = "More than 5 steps, but subject recovers unaided." },
					new Option { Value = 3, Name = "Moderate", Description = "Stands safely, but with absence of postural response; falls if not caught by examiner." },
					new Option { Value = 4, Name = "Severe", Description = "Very unstable, tends to lose balance spontaneously or with just a gentle pull on the shoulders." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.13",
                Label = "3.13 POSTURE",
				InstructionsForTheExaminer = "Posture is assessed with the patient standing erect after arising from a chair, during walking, and while being tested for postural reflexes. If you notice poor posture, tell the patient to stand up straight and see if the posture improves (see option 2 below). Rate the worst posture seen in these three observation points. Observe for flexion and side-to-side leaning.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Not quite erect, but posture could be normal for an older person." },
					new Option { Value = 2, Name = "Mild", Description = "Definite flexion, scoliosis, or leaning to one side, but the patient can correct posture to normal when asked to do so." },
					new Option { Value = 3, Name = "Moderate", Description = "Stooped posture, scoliosis, or leaning to one side that cannot be corrected volitionally to a normal posture by the patient." },
					new Option { Value = 4, Name = "Severe", Description = "Flexion, scoliosis, or leaning with extreme abnormality of posture." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.14",
                Label = "3.14 GLOBAL SPONTANEITY OF MOVEMENT (BODY BRADYKINESIA)",
				InstructionsForTheExaminer = "This global rating combines all observations on slowness, hesitancy, and small amplitude and poverty of movement in general, including a reduction of gesturing and of crossing the legs. This assessment is based on the examiner’s global impression after observing for spontaneous gestures while sitting, and the nature of arising and walking.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No problems." },
					new Option { Value = 1, Name = "Slight", Description = "Slight global slowness and poverty of spontaneous movements." },
					new Option { Value = 2, Name = "Mild", Description = "Mild global slowness and poverty of spontaneous movements." },
					new Option { Value = 3, Name = "Moderate", Description = "Moderate global slowness and poverty of spontaneous movements." },
					new Option { Value = 4, Name = "Severe", Description = "Severe global slowness and poverty of spontaneous movements." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.15R",
                Label = "3.15 POSTURAL TREMOR OF THE HANDS - RIGHT",
				InstructionsForTheExaminer = "All tremor, including re-emergent rest tremor, that is present in this posture is to be included in this rating. Rate each hand separately. Rate the highest amplitude seen. Instruct the patient to stretch the arms out in front of the body with palms down. The wrist should be straight and the fingers comfortably separated so that they do not touch each other. Observe this posture for 10 seconds.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Tremor is present but less than 1 cm in amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "Tremor is at least 1 but less than 3 cm in amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "Tremor is at least 3 but less than 10 cm in amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "Tremor is at least 10 cm in amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.15L",
                Label = "3.15 POSTURAL TREMOR OF THE HANDS - LEFT",
				InstructionsForTheExaminer = "All tremor, including re-emergent rest tremor, that is present in this posture is to be included in this rating. Rate each hand separately. Rate the highest amplitude seen. Instruct the patient to stretch the arms out in front of the body with palms down. The wrist should be straight and the fingers comfortably separated so that they do not touch each other. Observe this posture for 10 seconds.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Tremor is present but less than 1 cm in amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "Tremor is at least 1 but less than 3 cm in amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "Tremor is at least 3 but less than 10 cm in amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "Tremor is at least 10 cm in amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.16R",
                Label = "3.16 KINETIC TREMOR OF THE HANDS - RIGHT",
				InstructionsForTheExaminer = "This is tested by the finger-to-nose maneuver. With the arm starting from the outstretched position, have the patient perform at least three finger-to-nose maneuvers with each hand reaching as far as possible to touch the examiner’s finger. The finger-to-nose maneuver should be performed slowly enough not to hide any tremor that could occur with very fast arm movements. Repeat with the other hand, rating each hand separately. The tremor can be present throughout the movement or as the tremor reaches either target (nose or finger). Rate the highest amplitude seen.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Tremor is present but less than 1 cm in amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "Tremor is at least 1 but less than 3 cm in amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "Tremor is at least 3 but less than 10 cm in amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "Tremor is at least 10 cm in amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.16L",
                Label = "3.16 KINETIC TREMOR OF THE HANDS - LEFT",
				InstructionsForTheExaminer = "This is tested by the finger-to-nose maneuver. With the arm starting from the outstretched position, have the patient perform at least three finger-to-nose maneuvers with each hand reaching as far as possible to touch the examiner’s finger. The finger-to-nose maneuver should be performed slowly enough not to hide any tremor that could occur with very fast arm movements. Repeat with the other hand, rating each hand separately. The tremor can be present throughout the movement or as the tremor reaches either target (nose or finger). Rate the highest amplitude seen.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Tremor is present but less than 1 cm in amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "Tremor is at least 1 but less than 3 cm in amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "Tremor is at least 3 but less than 10 cm in amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "Tremor is at least 10 cm in amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.17RU",
                Label = "3.17 REST TREMOR AMPLITUDE Right Upper Extremity",
				InstructionsForTheExaminer = "This and the next item have been placed purposefully at the end of the examination to allow the rater to gather observations on rest tremor that may appear at any time during the exam, including when quietly sitting, during walking, and during activities when some body parts are moving but others are at rest. Score the maximum amplitude that is seen at any time as the final score. Rate only the amplitude and not the persistence or the intermittency of the tremor.\r\nAs part of this rating, the patient should sit quietly in a chair with the hands placed on the arms of the chair (not in the lap) and the feet comfortably supported on the floor for 10 seconds with no other directives. Rest tremor is assessed separately for all four limbs and also for the lip/jaw. Rate only the maximum amplitude that is seen at any time as the final rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "< 1 cm in maximal amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "≥ 1 cm but < 3 cm in maximal amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "≥ 3 cm but < 10 cm in maximal amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "≥ 10 cm in maximal amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.17LU",
                Label = "3.17 REST TREMOR AMPLITUDE Left Upper Extremity",
				InstructionsForTheExaminer = "This and the next item have been placed purposefully at the end of the examination to allow the rater to gather observations on rest tremor that may appear at any time during the exam, including when quietly sitting, during walking, and during activities when some body parts are moving but others are at rest. Score the maximum amplitude that is seen at any time as the final score. Rate only the amplitude and not the persistence or the intermittency of the tremor.\r\nAs part of this rating, the patient should sit quietly in a chair with the hands placed on the arms of the chair (not in the lap) and the feet comfortably supported on the floor for 10 seconds with no other directives. Rest tremor is assessed separately for all four limbs and also for the lip/jaw. Rate only the maximum amplitude that is seen at any time as the final rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "< 1 cm in maximal amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "≥ 1 cm but < 3 cm in maximal amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "≥ 3 cm but < 10 cm in maximal amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "≥ 10 cm in maximal amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.17RL",
                Label = "3.17 REST TREMOR AMPLITUDE Right Lower Extremity",
				InstructionsForTheExaminer = "This and the next item have been placed purposefully at the end of the examination to allow the rater to gather observations on rest tremor that may appear at any time during the exam, including when quietly sitting, during walking, and during activities when some body parts are moving but others are at rest. Score the maximum amplitude that is seen at any time as the final score. Rate only the amplitude and not the persistence or the intermittency of the tremor.\r\nAs part of this rating, the patient should sit quietly in a chair with the hands placed on the arms of the chair (not in the lap) and the feet comfortably supported on the floor for 10 seconds with no other directives. Rest tremor is assessed separately for all four limbs and also for the lip/jaw. Rate only the maximum amplitude that is seen at any time as the final rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "< 1 cm in maximal amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "≥ 1 cm but < 3 cm in maximal amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "≥ 3 cm but < 10 cm in maximal amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "≥ 10 cm in maximal amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.17LL",
                Label = "3.17 REST TREMOR AMPLITUDE Left Lower Extremity",
				InstructionsForTheExaminer = "This and the next item have been placed purposefully at the end of the examination to allow the rater to gather observations on rest tremor that may appear at any time during the exam, including when quietly sitting, during walking, and during activities when some body parts are moving but others are at rest. Score the maximum amplitude that is seen at any time as the final score. Rate only the amplitude and not the persistence or the intermittency of the tremor.\r\nAs part of this rating, the patient should sit quietly in a chair with the hands placed on the arms of the chair (not in the lap) and the feet comfortably supported on the floor for 10 seconds with no other directives. Rest tremor is assessed separately for all four limbs and also for the lip/jaw. Rate only the maximum amplitude that is seen at any time as the final rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "< 1 cm in maximal amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "≥ 1 cm but < 3 cm in maximal amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "≥ 3 cm but < 10 cm in maximal amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "≥ 10 cm in maximal amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.17J",
                Label = "3.17 REST TREMOR AMPLITUDE Lip/Jaw",
				InstructionsForTheExaminer = "This and the next item have been placed purposefully at the end of the examination to allow the rater to gather observations on rest tremor that may appear at any time during the exam, including when quietly sitting, during walking, and during activities when some body parts are moving but others are at rest. Score the maximum amplitude that is seen at any time as the final score. Rate only the amplitude and not the persistence or the intermittency of the tremor.\r\nAs part of this rating, the patient should sit quietly in a chair with the hands placed on the arms of the chair (not in the lap) and the feet comfortably supported on the floor for 10 seconds with no other directives. Rest tremor is assessed separately for all four limbs and also for the lip/jaw. Rate only the maximum amplitude that is seen at any time as the final rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "< 1 cm in maximal amplitude." },
					new Option { Value = 2, Name = "Mild", Description = "≥ 1 cm but < 2 cm in maximal amplitude." },
					new Option { Value = 3, Name = "Moderate", Description = "≥ 2 cm but < 3 cm in maximal amplitude." },
					new Option { Value = 4, Name = "Severe", Description = "≥ 3 cm in maximal amplitude." }
				}
			},
			new ComplexOptionsItem
            {
                JsonCode = "3.18",
                Label = "3.18 CONSTANCY OF REST TREMOR",
				InstructionsForTheExaminer = "This item receives one rating for all rest tremor and focuses on the constancy of rest tremor during the examination period when different body parts are variously at rest. It is rated purposefully at the end of the examination so that several minutes of information can be coalesced into the rating.",
				Options = new List<Option>
				{
					new Option { Value = 0, Name = "Normal", Description = "No tremor." },
					new Option { Value = 1, Name = "Slight", Description = "Tremor at rest is present ≤ 25% of the entire examination period." },
					new Option { Value = 2, Name = "Mild", Description = "Tremor at rest is present 26-50% of the entire examination period." },
					new Option { Value = 3, Name = "Moderate", Description = "Tremor at rest is present 51-75% of the entire examination period." },
					new Option { Value = 4, Name = "Severe", Description = "Tremor at rest is present > 75% of the entire examination period." }
				}
			},
			new OptionsItem
            {
                JsonCode = "DyskinesiasA",
                InstructionsForThePatient = "Were dyskinesias (chorea or dystonia) present during examination?",
				Options = new List<string> { "No", "Yes" },
				Label = "DYSKINESIA IMPACT ON PART III RATINGS .A"
			},
			new OptionsItem
            {
                JsonCode = "DiskinesiasB",
                InstructionsForThePatient = "If yes, did these movements interfere with your ratings?",
				Options = new List<string> { "No", "Yes" },
				Label = "DYSKINESIA IMPACT ON PART III RATINGS .B"
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
