using CompanionAppShared.Scales;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CompanionAppShared.Scales
{
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
	[JsonDerivedType(typeof(MoCA), typeDiscriminator: "MoCA")]
	[JsonDerivedType(typeof(BlocksAndBlocksTest), typeDiscriminator: "BnBT")]

	//When adding a new scale here, don't forget to add the entry in the ScaleService

	public interface IScale
    {
        string Name { get; set; }
        ScalesIDs Id { get; set; }
        string ShortName { get; set; }
		string AreaOfStudy { get; set; }

		int ScoreNormalized { get; }
        int ScoreRaw { get; set; }
        List<string> DetailsHeaders { get; set; }
        List<string> Details { get; set; }
        int ScoreDelta { get; }
        bool IsMeasured { get; set; } 
        int ReferenceScoreNormalized { get; set; }
        event EventHandler UpdateNeeded;

        void GenerateScore();
		void Reset();
		void FixEvents();
		void FixItems(Patient? patient = null);
		ScaleIcon Icon { get; set; }
		List<ScaleItem> Items { get; set; }

        Dictionary<string, string> ToDBDictionary();
		void LoadValuesFromDB(Dictionary<string,string> valuesInDb);

	}


	public enum ScaleIcon { NotSet, NINEhptIcon, SIXminWalk, TwentyFiveFootWalk, Arm, bbt, hand, MAS, MFIS, MSIS, pencil, recoveriX, sessions, TUG }
}
