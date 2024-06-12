using Dapper;
using Infrastructure.SqlMappers;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure.DataBase;

public class DataBaseContext(IConfiguration configuration) : Domain.Interfaces.DataBase.IDataBaseContext
{
    public async Task SaveDataAsync(string connectionName, string sqlQuery, object? parameters = null)
    {
        VerifyConnectionNameAndSqlQueryIsNullorEmpty(connectionName, sqlQuery);
        UpdateTypesHandlers();

        using var conn = CreateConnection(connectionName);

        try
        {
            conn.Open();
            await conn.ExecuteAsync(sqlQuery, parameters);
        }
        catch (Exception ex) { }
    }

    public async Task<IEnumerable<T?>> LoadDataListAsync<T>(string connectionName, string sqlQuery, object? parameters = null)
    {
        VerifyConnectionNameAndSqlQueryIsNullorEmpty(connectionName, sqlQuery);
        UpdateTypesHandlers();

        using var conn = CreateConnection(connectionName);

        conn.Open();
        return await conn.QueryAsync<T>(sqlQuery, parameters);
    }

    public async Task<T?> LoadDataAsync<T>(string connectionName, string sqlQuery, object? parameters = null)
    {
        VerifyConnectionNameAndSqlQueryIsNullorEmpty(connectionName, sqlQuery);
        UpdateTypesHandlers();

        using var conn = CreateConnection(connectionName);

        conn.Open();
        return await conn.QueryFirstOrDefaultAsync<T>(sqlQuery, parameters);
    }

    private IDbConnection CreateConnection(string connectionName)
    {
        try
        {
            var connectionstring = configuration.GetConnectionString(connectionName);
            return new NpgsqlConnection(connectionstring);
        }catch(Exception ex)
        {
            return null;
        }
    }

    private static void VerifyConnectionNameAndSqlQueryIsNullorEmpty(string connectionName, string sqlQuery)
    {
        if (string.IsNullOrWhiteSpace(connectionName))
            throw new ArgumentNullException(nameof(connectionName));

        if (string.IsNullOrWhiteSpace(sqlQuery))
            throw new ArgumentNullException(nameof(sqlQuery));
    }

    private static void UpdateTypesHandlers()
    {
        SqlMapper.AddTypeHandler(new GuidTypeHandler());
    }
}