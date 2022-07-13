

using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace TasksManagementSystem.DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task SaveData<T>(string query, T parameters)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("Default"));
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("Default"));
        return await connection.QueryAsync<T>(query, parameters);
    }

}

