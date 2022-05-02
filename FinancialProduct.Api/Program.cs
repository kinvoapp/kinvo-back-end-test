using FinancialProduct.Domain.Handlers;
using FinancialProduct.Domain.Repositories;
using FinancialProduct.Infra.Contexts;
using Form.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt=>opt.UseInMemoryDatabase("DataContext"));

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ProductHandler, ProductHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();