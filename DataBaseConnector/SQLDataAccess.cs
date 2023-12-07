using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataBaseConnector;

public class SQLDataAccess : ISQLDataAccess
{
	private readonly IConfiguration config;

	public event EventHandler<Exception> OnNewError;


	public SQLDataAccess(IConfiguration config)
	{
		this.config = config;
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(
		string storedProcedure,
		U parameters,
		string connectonID = "Default")
	{
		try
		{
			using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectonID));
			return await connection.QueryAsync<T>(
				storedProcedure,
				parameters,
				commandType: CommandType.StoredProcedure);
		}catch(Exception ex) {
			OnNewError?.Invoke(this, ex);
			return Enumerable.Empty<T>();
		}
	}

	public async Task SaveData<T>(
		string storedProcedure,
		T parameters,
		string connectonID = "Default")
	{
		try
		{
			using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectonID));
			await connection.ExecuteAsync(
				storedProcedure,
				parameters,
				commandType: CommandType.StoredProcedure);
		}
		catch (Exception ex)
		{
			OnNewError?.Invoke(this, ex);
			throw;
		}
	}
}