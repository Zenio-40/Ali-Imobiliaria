using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.PerfilUseCase.Command;
using Corretora.C02.Aplication.CasosUso.PerfilUseCase.DTOs;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerfilController : ControllerBase
{
    private readonly CadastrarPerfil _cadastrarPerfil;

    public PerfilController(CadastrarPerfil cadastrarPerfil)
    {
        _cadastrarPerfil = cadastrarPerfil;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarPerfilDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _cadastrarPerfil.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }
}

