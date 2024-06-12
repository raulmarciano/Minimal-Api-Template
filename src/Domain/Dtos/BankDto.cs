using Domain.Entities;

namespace Domain.Dtos;

public class BankDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? BacenCode { get; set; }
    public string? Ispb { get; set; }

    public static implicit operator BankEntity(BankDto bankDto)
    {
        return new()
        {
            Id = bankDto.Id,
            Name = bankDto.Name,
            Description = bankDto.Description,
            BacenCode = bankDto.BacenCode,
            Ispb = bankDto.Ispb
        };
    }
}