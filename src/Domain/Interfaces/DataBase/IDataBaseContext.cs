namespace Domain.Interfaces.DataBase;

public interface IDataBaseContext
{
    Task<T?> LoadDataAsync<T>(string connectionName, string sqlQuery, object? parameters = null);
    Task<IEnumerable<T?>> LoadDataListAsync<T>(string connectionName, string sqlQuery, object? parameters = null);
    Task SaveDataAsync(string connectionName, string sqlQuery, object? parameters = null);
}