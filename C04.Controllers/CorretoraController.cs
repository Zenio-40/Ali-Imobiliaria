using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/corretora")]
[Authorize]
public class CorretoraController : ControllerBase
{
    private readonly PesquisarImoveisDisponiveis _pesquisarImoveis;
    private readonly PesquisarTodosClientes _pesquisarClientes;
    private readonly PesquisarTodosProprietarios _pesquisarProprietarios;

    public CorretoraController(
        PesquisarImoveisDisponiveis pesquisarImoveis,
        PesquisarTodosClientes pesquisarClientes,
        PesquisarTodosProprietarios pesquisarProprietarios)
    {
        _pesquisarImoveis = pesquisarImoveis;
        _pesquisarClientes = pesquisarClientes;
        _pesquisarProprietarios = pesquisarProprietarios;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var (imoveis, _, _) = await _pesquisarImoveis.Executar(1, 100);
        var (clientes, _, _) = await _pesquisarClientes.Executar(1, 100);
        var (proprietarios, _, _) = await _pesquisarProprietarios.Executar(1, 100);

        return Ok(new
        {
            mensagem = "Dashboard da Corretora",
            estatisticas = new
            {
                totalImoveis = imoveis?.Count() ?? 0,
                totalClientes = clientes?.Count() ?? 0,
                totalProprietarios = proprietarios?.Count() ?? 0
            }
        });
    }

    [HttpGet("imoveis")]
    public async Task<IActionResult> GetImoveis([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarImoveis.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("clientes")]
    public async Task<IActionResult> GetClientes([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarClientes.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("proprietarios")]
    public async Task<IActionResult> GetProprietarios([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarProprietarios.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }
}
