﻿using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace CompanionAppShared.Scales;



public abstract class ScaleBase : IScale
{
    public ScaleBase() 
    {
		FixEvents();
	}

	public void FixEvents()
	{
		Items.Clear();
		foreach (var property in this.GetType().GetProperties())
		{
			if (typeof(ScaleItem).IsAssignableFrom(property.GetValue(this).GetType()))
			{
				ScaleItem customItem = (ScaleItem)property.GetValue(this);
				if (customItem is not null)
				{
					Items.Add(customItem);
					customItem.ParentScale = this;
					customItem.UpdateNeeded -= Update;
					customItem.UpdateNeeded += Update;
					customItem.FormatError -= Invalidate;
					customItem.FormatError += Invalidate;
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

    [JsonIgnore]
    public List<ScaleItem> Items { get; set; } = new();

	
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
