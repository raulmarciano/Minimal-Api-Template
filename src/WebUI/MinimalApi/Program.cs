using Domain.Dtos;
using Domain.Interfaces.DataBase;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using Infrastructure.DataBase;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Banks", ([FromBody] BankDto bankDto, [FromServices] IBankService _bankService) =>
{
    _bankService.CreateAsync(bankDto);
});

app.MapGet("/Banks", ([FromServices] IBankService _bankService) =>
{
    return _bankService.GetAllAsync();
});

app.MapGet("/Banks/{id}", ([FromHeader] Guid id, [FromServices] IBankService _bankService) =>
{
    return _bankService.GetByIdAsync(id);
});

app.MapPut("/Banks/{id}", ([FromHeader] Guid id, [FromBody] BankDto bankDto, [FromServices] IBankService _bankService) =>
{
    return _bankService.UpdateAsync(id, bankDto);
});

app.MapDelete("/Banks/{id}", ([FromHeader]Guid id, [FromServices] IBankService _bankService) =>
{
    _bankService.DeleteAsync(id);
});

app.Run();
