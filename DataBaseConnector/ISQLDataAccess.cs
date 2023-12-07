namespace DataBaseConnector
{
	public interface ISQLDataAccess
	{
		Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectonID = "Default");
		Task SaveData<T>(string storedProcedure, T parameters, string connectonID = "Default");

		event EventHandler<Exception> OnNewError;
	}
}