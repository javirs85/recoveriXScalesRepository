using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace CompanionAppShared.Scales;

[JsonDerivedType(typeof(NineHolePegTest), typeDiscriminator: "NineHolePegTest")]
[JsonDerivedType(typeof(ATA), typeDiscriminator: "ATA")]
[JsonDerivedType(typeof(ERP), typeDiscriminator: "ERP")]
[JsonDerivedType(typeof(FOGQ), typeDiscriminator: "FOGQ")]
[JsonDerivedType(typeof(HYClass), typeDiscriminator: "HYClass")]
[JsonDerivedType(typeof(MFIS), typeDiscriminator: "MFIS")]
[JsonDerivedType(typeof(miniBESTest), typeDiscriminator: "miniBESTest")]
[JsonDerivedType(typeof(PDQ39), typeDiscriminator: "PDQ39")]
[JsonDerivedType(typeof(SEADL), typeDiscriminator: "SEADL")]
[JsonDerivedType(typeof(TENMWT), typeDiscriminator: "TENMWT")]
[JsonDerivedType(typeof(TUG), typeDiscriminator: "TUG")]
[JsonDerivedType(typeof(UPDRSI), typeDiscriminator: "UPDRSI")]
[JsonDerivedType(typeof(UPDRSII), typeDiscriminator: "UPDRSII")]
[JsonDerivedType(typeof(UPDRSIII), typeDiscriminator: "UPDRSIII")]
[JsonDerivedType(typeof(UPDRSIV), typeDiscriminator: "UPDRSIV")]

//When adding a new scale here, don't forget to add the entry in the ScaleService

public abstract class ScaleBase : IScale
{
    public ScaleBase() 
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
    public int ScoreNormalized { get; internal set; } = -1;
    public int ScoreDelta
    {
        get {
            return ScoreNormalized - ReferenceScoreNormalized;
        }
    }
    public bool IsMeasured { get; set; }= false;
    public int ReferenceScoreNormalized { get; set; } = 0;
	public int ScoreRaw { get; set; }
	public List<string> Details { get; set; } = new List<string>();

    public List<ScaleItem> Items { get; set; } = new();

	

	public string Serialize()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        return JsonSerializer.Serialize(this, options);
    }

	public void GenerateScore()
	{
        IsMeasured = GenerateScoreInternal();
	}

	protected abstract bool GenerateScoreInternal();
    public void Reset()
    {
        IsMeasured = false;
        ResetInternal();
    }
    protected abstract void ResetInternal();
}
