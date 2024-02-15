

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales;


public class PDQ39 : ScaleBase
{
    public PDQ39()
    {
		Id = ScalesIDs.PDQ39;
		Name = "Parkinson's Disease Questionnaire";
		ShortName = "PDQ39";
		AreaOfStudy = "Impact of the disease";
    }


	public IntItem q1 { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public IntItem q2 { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };
	public IntItem q3 { get; set; } = new IntItem { Label = "Test int", StringValue = "12" };

	public OptionsItem OptionsItem { get; set; } = new OptionsItem
	{
		Options = new List<string> { "option 1", "option 2", "option 3" },
		Label = "Select your option:"
	};
	protected override void GenerateScoreInternal()
	{
		//suma de cada pregunta, amb valors 0..4 per cada pregunta
		//score normalitzat = mitja
	}
	protected override void GenerateDetails()
	{
		//suma sense normalitzar
	}
	protected override void ResetInternal()
	{
	}
}
