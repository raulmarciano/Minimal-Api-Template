using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;

namespace Service.Services;

public class BankService(IBankRepository bankRepository) : IBankService
{
    private readonly IBankRepository _bankRepository = bankRepository;

    public async Task CreateAsync(BankDto bankDto)
    {
        await _bankRepository.CreateAsync(bankDto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _bankRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BankDto?>> GetAllAsync()
    {
        //TODO: Criar Mapper
        var teste = await _bankRepository.GetAllAsync();

        return null;
    }

    public async Task<BankDto?> GetByIdAsync(Guid id)
    {
        var teste = await _bankRepository.GetAllAsync();

        return null;
    }

    public async Task UpdateAsync(Guid id, BankDto bankDto)
    {
        bankDto.Id = id;

        await _bankRepository.UpdateAsync(bankDto);
    }
}