﻿

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class NineHolePegTest : ScaleBase
{
    public NineHolePegTest()
    {
		Id = ScalesIDs.NineHPT;
		Name = "Nine hole peg test";
		ShortName = "9HPT";
		AreaOfStudy = "Dexterity";
	}

    public int TimeInSecondsPareticHand { get; set; }
	public int TimeInSecondsHealthyHand { get; set; }


	public TimeOnly TimeParetic => TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(TimeInSecondsPareticHand));
	public TimeOnly TimeHealthy => TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(TimeInSecondsHealthyHand));
	public string TimePareticUI => TimeParetic.ToShortTimeString();
	public string TimeHealthyUI => TimeHealthy.ToShortTimeString();



	public override void GenerateScore()
	{
	}
}