using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IBankRepository
{
    Task CreateAsync(BankEntity bankEntity);
    Task<BankEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<BankEntity?>> GetAllAsync();
    Task UpdateAsync(BankEntity bankEntity);
    Task DeleteAsync(Guid id);
}