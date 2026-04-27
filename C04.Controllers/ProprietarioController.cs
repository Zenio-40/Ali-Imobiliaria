using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.ProprietarioUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProprietarioController : ControllerBase
{
    private readonly CadastrarProprietario _cadastrarProprietario;
    private readonly ActualizarProprietario _actualizarProprietario;
    private readonly PesquisarProprietarioPorId _pesquisarProprietarioPorId;
    private readonly PesquisarTodosProprietarios _pesquisarTodosProprietarios;

    public ProprietarioController(
        CadastrarProprietario cadastrarProprietario,
        ActualizarProprietario actualizarProprietario,
        PesquisarProprietarioPorId pesquisarProprietarioPorId,
        PesquisarTodosProprietarios pesquisarTodosProprietarios)
    {
        _cadastrarProprietario = cadastrarProprietario;
        _actualizarProprietario = actualizarProprietario;
        _pesquisarProprietarioPorId = pesquisarProprietarioPorId;
        _pesquisarTodosProprietarios = pesquisarTodosProprietarios;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarProprietarioDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _cadastrarProprietario.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPut]
    public async Task<IActionResult> Actualizar([FromBody] ActualizarProprietarioDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _actualizarProprietario.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarTodosProprietarios.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var (dados, mensagem, codigo) = await _pesquisarProprietarioPorId.Executar(id);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }
}

