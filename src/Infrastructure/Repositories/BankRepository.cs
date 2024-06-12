using Domain.Entities;
using Domain.Interfaces.DataBase;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class BankRepository : IBankRepository
{
    private readonly IDataBaseContext _baseRepository;
    private readonly string connectionName;

    public BankRepository(IDataBaseContext baseRepository)
    {
        _baseRepository = baseRepository;
        connectionName = "DefaultConnection";
    }

    public async Task CreateAsync(BankEntity bankEntity)
    {
        string sql = @"INSERT 
                        INTO bank
                        (
                            id, 
                            name, 
                            description, 
                            bacen_code, 
                            Ispb
                        )
                        VALUES
                        (
                            @Id, 
                            @Name, 
                            @Description, 
                            @BacenCode, 
                            @Ispb
                        )";

        try
        {
            await _baseRepository.SaveDataAsync(connectionName, sql, bankEntity);
        }
        catch (Exception ex) { }
    }

    public async Task<IEnumerable<BankEntity?>> GetAllAsync()
    {
        var sql = @"SELECT 
                        id, 
                        name, 
                        description, 
                        bacen_code, 
                        ispb
                    FROM
                        bank";

        return await _baseRepository.LoadDataListAsync<BankEntity>("DefaultConnection", sql);
    }

    public async Task<BankEntity?> GetByIdAsync(Guid id)
    {
        var sql = @"SELECT 
                        id, 
                        name, 
                        description, 
                        bacenCode, 
                        ispb
                    FROM
                        bank
                    WHERE
                        id = @id";

        return await _baseRepository.LoadDataAsync<BankEntity>(connectionName, sql, id);
    }

    public async Task UpdateAsync(BankEntity bank)
    {
        var sql = @"UPDATE bank
                        SET
                            name = @Name,
                            description = @Description, 
                            bacen_code = @BacenCode, 
                            ispb = @Ispb
                    WHERE
                        id = @Id";

        await _baseRepository.SaveDataAsync(connectionName, sql, bank);
    }

    public async Task DeleteAsync(Guid id)
    {
        var sql = @"DELETE 
                        FROM bank
                        WHERE
                            id = @id";

        await _baseRepository.SaveDataAsync(connectionName, sql, id);
    }
}