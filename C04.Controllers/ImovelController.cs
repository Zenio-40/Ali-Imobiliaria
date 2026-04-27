using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImovelController : ControllerBase
{
    private readonly CadastrarImovel _cadastrarImovel;
    private readonly ActualizarImovel _actualizarImovel;
    private readonly DesativarImovel _desativarImovel;
    private readonly PesquisarImovelPorId _pesquisarImovelPorId;
    private readonly PesquisarImoveisDisponiveis _pesquisarImoveisDisponiveis;

    public ImovelController(
        CadastrarImovel cadastrarImovel,
        ActualizarImovel actualizarImovel,
        DesativarImovel desativarImovel,
        PesquisarImovelPorId pesquisarImovelPorId,
        PesquisarImoveisDisponiveis pesquisarImoveisDisponiveis)
    {
        _cadastrarImovel = cadastrarImovel;
        _actualizarImovel = actualizarImovel;
        _desativarImovel = desativarImovel;
        _pesquisarImovelPorId = pesquisarImovelPorId;
        _pesquisarImoveisDisponiveis = pesquisarImoveisDisponiveis;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarImovelDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _cadastrarImovel.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPut]
    public async Task<IActionResult> Actualizar([FromBody] ActualizarImovelDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _actualizarImovel.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPatch("{id}/desativar")]
    public async Task<IActionResult> Desativar(int id)
    {
        var (sucesso, mensagem, codigo) = await _desativarImovel.Executar(id);
        return StatusCode(codigo, new { sucesso, mensagem, codigo });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var (dados, mensagem, codigo) = await _pesquisarImovelPorId.Executar(id);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("disponiveis")]
    public async Task<IActionResult> ListarDisponiveis([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarImoveisDisponiveis.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }
}
