using Domain.Dtos;

namespace Domain.Interfaces.Service;

public interface IBankService
{
    Task CreateAsync(BankDto bankDto);
    Task<IEnumerable<BankDto?>> GetAllAsync();
    Task<BankDto?> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, BankDto bankDto);
    Task DeleteAsync(Guid id);
}