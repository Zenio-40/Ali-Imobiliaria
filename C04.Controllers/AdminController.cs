using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly CadastrarFuncionario _cadastrarFuncionario;

    public AdminController(CadastrarFuncionario cadastrarFuncionario)
    {
        _cadastrarFuncionario = cadastrarFuncionario;
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
}