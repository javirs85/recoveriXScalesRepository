using System.Text.Json;
using System.Text.Json.Serialization;

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

public class ScaleBase : IScale
{
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

	public string Serialize()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        return JsonSerializer.Serialize(this, options);
    }

    public virtual void GenerateScore() => ScoreRaw = -1;
}
