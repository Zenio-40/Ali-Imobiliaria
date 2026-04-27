using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.Command;
using Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SolicitacaoController : ControllerBase
{
    private readonly CadastrarSolicitacao _cadastrarSolicitacao;
    private readonly ActualizarEstadoSolicitacao _actualizarEstadoSolicitacao;
    private readonly PesquisarSolicitacaoPorId _pesquisarSolicitacaoPorId;
    private readonly PesquisarSolicitacoesDoCliente _pesquisarSolicitacoesDoCliente;

    public SolicitacaoController(
        CadastrarSolicitacao cadastrarSolicitacao,
        ActualizarEstadoSolicitacao actualizarEstadoSolicitacao,
        PesquisarSolicitacaoPorId pesquisarSolicitacaoPorId,
        PesquisarSolicitacoesDoCliente pesquisarSolicitacoesDoCliente)
    {
        _cadastrarSolicitacao = cadastrarSolicitacao;
        _actualizarEstadoSolicitacao = actualizarEstadoSolicitacao;
        _pesquisarSolicitacaoPorId = pesquisarSolicitacaoPorId;
        _pesquisarSolicitacoesDoCliente = pesquisarSolicitacoesDoCliente;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarSolicitacaoDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _cadastrarSolicitacao.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPut("estado")]
    public async Task<IActionResult> ActualizarEstado([FromBody] ActualizarEstadoSolicitacaoDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _actualizarEstadoSolicitacao.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var (dados, mensagem, codigo) = await _pesquisarSolicitacaoPorId.Executar(id);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ListarPorCliente(int clienteId, [FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarSolicitacoesDoCliente.Executar(clienteId, pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }
}

