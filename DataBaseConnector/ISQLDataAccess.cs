namespace DataBaseConnector
{
	public interface ISQLDataAccess
	{
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionID = "Default");
		Task SaveData<T>(string storedProcedure, T parameters, string connectionID = "Default");
		Task<int> Count(string query, string connectionID = "Default");

		event EventHandler<Exception> OnNewError;
	}
}