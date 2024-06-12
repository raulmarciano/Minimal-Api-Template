namespace Domain.Entities;

public class BankEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set;}
    public string? Description { get; set;}
    public string? BacenCode { get; set; }
    public string? Ispb { get; set; }
}