using Corretora;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string conexao = builder.Configuration.GetConnectionString("ConexaoLocal")!;
builder.Services.AddDbContext<CorretoraDbContext>(options => options.UseNpgsql(conexao));
builder.Services.AddContratos();

builder.Services.AddDbContext<CorretoraDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
