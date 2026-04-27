using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly CadastrarFuncionario _cadastrarFuncionario;
    private readonly ActualizarFuncionario _actualizarFuncionario;
    private readonly DesativarFuncionario _desativarFuncionario;
    private readonly PesquisarFuncionarioPorId _pesquisarFuncionarioPorId;
    private readonly PesquisarTodosFuncionarios _pesquisarTodosFuncionarios;

    public AdminController(
        CadastrarFuncionario cadastrarFuncionario,
        ActualizarFuncionario actualizarFuncionario,
        DesativarFuncionario desativarFuncionario,
        PesquisarFuncionarioPorId pesquisarFuncionarioPorId,
        PesquisarTodosFuncionarios pesquisarTodosFuncionarios)
    {
        _cadastrarFuncionario = cadastrarFuncionario;
        _actualizarFuncionario = actualizarFuncionario;
        _desativarFuncionario = desativarFuncionario;
        _pesquisarFuncionarioPorId = pesquisarFuncionarioPorId;
        _pesquisarTodosFuncionarios = pesquisarTodosFuncionarios;
    }

    [HttpPost("funcionarios")]
    public async Task<IActionResult> CadastrarFuncionario([FromBody] CadastrarFuncionarioDTO dto)
    {
        if (!ModelState.IsValid) return StatusCode(400, ModelState);
        var (dados, mensagem, codigo) = await _cadastrarFuncionario.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("funcionarios")]
    public async Task<IActionResult> ListarFuncionarios([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarTodosFuncionarios.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("funcionarios/{id}")]
    public async Task<IActionResult> ObterFuncionario(int id)
    {
        var (dados, mensagem, codigo) = await _pesquisarFuncionarioPorId.Executar(id);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPut("funcionarios")]
    public async Task<IActionResult> ActualizarFuncionario([FromBody] ActualizarFuncionarioDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _actualizarFuncionario.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPatch("funcionarios/{id}/desativar")]
    public async Task<IActionResult> DesativarFuncionario(int id)
    {
        var (sucesso, mensagem, codigo) = await _desativarFuncionario.Executar(id);
        return StatusCode(codigo, new { sucesso, mensagem, codigo });
    }
}
