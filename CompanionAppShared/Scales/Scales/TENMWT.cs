

using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class TENMWT : ScaleBase
{
    public TENMWT()
    {
		Id = ScalesIDs.TENMWT;
		Name = "10 Meter Walk Test";
		ShortName = "10MWT";
		AreaOfStudy = "Gait";
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
	}
	protected override void GenerateDetails()
	{
		Details.Clear();
		Details.Add
	}
	protected override void ResetInternal()
	{
	}
}
