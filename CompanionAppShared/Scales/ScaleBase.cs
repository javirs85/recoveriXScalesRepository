using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace CompanionAppShared.Scales;



public abstract class ScaleBase : IScale
{
    public ScaleBase() 
    {
		FixItemsInternal();
		FixEvents();
	}

	/// <summary>
	/// Finds the linear interpolation of a rect that croses (x,y0) and (100, y100) then evaluates this line for xToInvestigate. Results are caped at 0..100
	/// </summary>
	/// <param name="X0">the value you mus enter to get a zero</param>
	/// <param name="X100">the value you must enter t o get a 100</param>
	/// <param name="xToInvestigate">the value you want to investigate</param>
	/// <returns></returns>
	public static double LinearInterpolation(double x100, double x0, double xToInvestigate)
	{
		// Perform linear interpolation
		double slope = 100 / (x100 - x0);
		double result = 100 - slope * (x100 - xToInvestigate);

		// Ensure the result is within the 0-100 range
		return Math.Max(0, Math.Min(100, result));
	}

	public void FixItems(Patient? patient = null)
	{
		Patient = patient;
		FixItemsInternal();
	}

	public abstract void FixItemsInternal();

	public void FixEvents()
	{
		foreach(var customItem in Items)
		{
			customItem.ParentScale = this;
			customItem.UpdateNeeded -= Update;
			customItem.UpdateNeeded += Update;
			customItem.FormatError -= Invalidate;
			customItem.FormatError += Invalidate;

			if(customItem is ConditionalSectionsPack)
			{
				var pack = (ConditionalSectionsPack)customItem;
				foreach(var section in pack.ConditionalSections)
				{
					foreach(var item in section.Items)
					{
						item.ParentScale = this;
						item.UpdateNeeded -= Update;
						item.UpdateNeeded += Update;
						item.FormatError -= Invalidate;
						item.FormatError += Invalidate;
					}
					
				}
			}
		}
	}

	private void Update(object? sender, EventArgs e)
    {
        GenerateScore();
        UpdateNeeded?.Invoke(this, EventArgs.Empty);
    }
    private void Invalidate(object? sender, string e)
    {
        IsMeasured = false;
    }

    public event EventHandler UpdateNeeded;
    public ScalesIDs Id { get; set; } = ScalesIDs.NotSet;
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public string AreaOfStudy { get; set; } = string.Empty;
	public ScaleIcon Icon { get; set; } = ScaleIcon.NotSet;
    public int ScoreNormalized { get; set; } = -1;
    public int ScoreDelta
    {
        get {
            return ScoreNormalized - ReferenceScoreNormalized;
        }
    }
    public bool IsMeasured { get; set; }= false;
    public int ReferenceScoreNormalized { get; set; } = 0;
	public int ScoreRaw { get; set; }
	public List<string> DetailsHeaders { get; set; } = new List<string>();
	public List<string> Details { get; set; } = new List<string>();
    public List<ScaleItem> Items { get; set; } = new();

	protected Patient? Patient;

	
	public void GenerateScore()
	{
		GenerateScoreInternal();
		Details.Clear();
		GenerateDetails();
		IsMeasured = true;
	}
	
    public void Reset()
    {
        IsMeasured = false;
        ResetInternal();
    }

    protected abstract void ResetInternal();
	protected abstract void GenerateScoreInternal();
    protected abstract void GenerateDetails();

}
