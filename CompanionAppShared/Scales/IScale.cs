namespace CompanionAppShared.Scales
{
    public interface IScale
    {
        string Name { get; set; }
        ScalesIDs Id { get; set; }
        string ShortName { get; set; }
        int ScoreNormalized { get; }
        int ScoreRaw { get; set; }
        List<string> Details { get; set; }
        int ScoreDelta { get; }
        bool IsMeasured { get; set; } 
        int ReferenceScoreNormalized { get; set; }
        event EventHandler UpdateNeeded;

        string SerializedData { get; set; }


		string Serialize();
        void GenerateScore();
		void Reset();
	}
}