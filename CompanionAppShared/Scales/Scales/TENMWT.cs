

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TENMWT : ScaleBase
{
    public TENMWT()
    {
		
	}

	public override void Init()
	{
		Id = ScalesIDs.TENMWT;
		Name = "10 Meter Walk Test";
		ShortName = "10MWT";
		AreaOfStudy = "Gait";
		DetailsHeaders.Add("Attempts");
	}



	public override void FixItemsInternal()
	{
		Items.Clear();
		Items.Add(MeasuredTimeExecution1);
		Items.Add(MeasuredTimeExecution2);
		Items.Add(MeasuredTimeExecution3);
	}

	public TimeSpanItem MeasuredTimeExecution1 { get; set; } = new TimeSpanItem { Label = "Time for central 6 meters:" };
	public TimeSpanItem MeasuredTimeExecution2 { get; set; } = new TimeSpanItem { Label = "Time for central 6 meters:" };
	public TimeSpanItem MeasuredTimeExecution3 { get; set; } = new TimeSpanItem { Label = "Time for central 6 meters:" };

	protected override void GenerateScoreInternal()
	{
		//calculate velocity
		//ignore values when equal to zero
		//normalizat amb valors de referencia
		//score = mijana de valors no-zero

		//TODO: Marc provide reference values
		ScoreNormalized = 50;
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add(MeasuredTimeExecution1.StringValue);
		Details.Add(MeasuredTimeExecution2.StringValue);
		Details.Add(MeasuredTimeExecution3.StringValue);
	}
	protected override void ResetInternal()
	{
	}

	public override void LoadValuesFromDB(string valuesInDb)
	{
		var dbItems = ParseDbString(valuesInDb, 3);

		MeasuredTimeExecution1.StringValue = dbItems[0];
		MeasuredTimeExecution2.StringValue = dbItems[1];
		MeasuredTimeExecution3.StringValue = dbItems[2];
	}

	public override string ToDBString()
	{
		return CreateDBItem(
			new List<string>
			{
				"first run",
				"second run",
				"third run"
			},
			new List<string>
			{
				MeasuredTimeExecution1.StringValue,
				MeasuredTimeExecution2.StringValue,
				MeasuredTimeExecution3.StringValue
			});
	}

	public override void FromDBString(string dbString)
	{
		var dbItems = ParseDbString(dbString, 2);

		MeasuredTimeExecution1.StringValue = dbItems[0];
		MeasuredTimeExecution2.StringValue = dbItems[1];
		MeasuredTimeExecution3.StringValue = dbItems[2];
	}
}
