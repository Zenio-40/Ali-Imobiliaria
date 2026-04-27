using Corretora;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.FavoritoUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FavoritoUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.Command;
using Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.Queries;
using Corretora.C03.Infra.Repositorios.E04_funcionario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string conexao = builder.Configuration.GetConnectionString("ConexaoLocal")!;
builder.Services.AddDbContext<CorretoraDbContext>(options => options.UseNpgsql(conexao));


builder.Services.AddDbContext<CorretoraDbContext>();

builder.Services.AddScoped<CadastrarFuncionario>();
builder.Services.AddScoped<ActualizarFuncionario>();
builder.Services.AddScoped<DesativarFuncionario>();
builder.Services.AddScoped<PesquisarFuncionarioPorId>();
builder.Services.AddScoped<PesquisarTodosFuncionarios>();

builder.Services.AddScoped<CadastrarCliente>();
builder.Services.AddScoped<ActualizarCliente>();
builder.Services.AddScoped<PesquisarClientePorId>();
builder.Services.AddScoped<PesquisarTodosClientes>();

builder.Services.AddScoped<CadastrarImovel>();
builder.Services.AddScoped<ActualizarImovel>();
builder.Services.AddScoped<DesativarImovel>();
builder.Services.AddScoped<PesquisarImovelPorId>();
builder.Services.AddScoped<PesquisarImoveisDisponiveis>();

builder.Services.AddScoped<AdicionarFavorito>();
builder.Services.AddScoped<RemoverFavorito>();
builder.Services.AddScoped<ListarFavoritosDoCliente>();

builder.Services.AddScoped<CadastrarSolicitacao>();
builder.Services.AddScoped<ActualizarEstadoSolicitacao>();
builder.Services.AddScoped<PesquisarSolicitacaoPorId>();
builder.Services.AddScoped<PesquisarSolicitacoesDoCliente>();

builder.Services.AddScoped<CadastrarProprietario>();
builder.Services.AddScoped<ActualizarProprietario>();
builder.Services.AddScoped<PesquisarProprietarioPorId>();
builder.Services.AddScoped<PesquisarTodosProprietarios>();

builder.Services.AddContratos();

// JWT Configuration
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"] ?? "default_secret_key");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
