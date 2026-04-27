using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginCommand _loginFuncionario;

    public AuthController(LoginCommand loginFuncionario)
    {
        _loginFuncionario = loginFuncionario;
    }

    /// <summary>
    /// Autentica um funcionário (admin/corretor) usando telefone e senha.
    /// </summary>
    [HttpPost("login/funcionario")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginFuncionario([FromBody] LoginDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (token, mensagem, codigo) = await _loginFuncionario.Executar(dto);
        return StatusCode(codigo, new { token, mensagem, codigo });
    }
}
