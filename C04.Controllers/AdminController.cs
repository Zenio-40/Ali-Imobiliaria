using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly CadastrarFuncionario _cadastrarFuncionario;
    private readonly LoginCommand _loginCommand;

    public AdminController(CadastrarFuncionario cadastrarFuncionario, LoginCommand loginCommand)
    {
        _cadastrarFuncionario = cadastrarFuncionario;
        _loginCommand = loginCommand;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarFuncionario([FromBody] CadastrarFuncionarioDTO dto)
    {

       if (!ModelState.IsValid) return StatusCode(400, ModelState);

       var (dados, mensagem, codigo) = await _cadastrarFuncionario.Executar(dto);
        return StatusCode(codigo, new
        {
            dados,
            mensagem,
            codigo
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (token, mensagem, codigo) = await _loginCommand.Executar(dto);
        return StatusCode(codigo, new
        {
            token,
            mensagem,
            codigo
        });
    }
}