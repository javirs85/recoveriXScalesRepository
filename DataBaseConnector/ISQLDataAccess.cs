namespace DataBaseConnector
{
	public interface ISQLDataAccess
	{
<<<<<<< HEAD
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionID = "Default");
		Task SaveData<T>(string storedProcedure, T parameters, string connectionID = "Default");
		Task<int> Count(string query, string connectionID = "Default");
=======
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectonID = "Default");
		Task SaveData<T>(string storedProcedure, T parameters, string connectonID = "Default");

		event EventHandler<Exception> OnNewError;
>>>>>>> b6ba10a4a19e560fbdd16c842b54e789c89c5bec
	}
}