namespace CompanionAppShared
{
	public interface IScale
	{
		string Name { get; set; }
		ScalesIDs Id { get; set; }
		string ShortName { get; set; }

		string Serialize();
	}
}