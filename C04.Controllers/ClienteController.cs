using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClienteController : ControllerBase
{
    [HttpGet("imoveis")]
    public IActionResult GetImoveisDisponiveis()
    {
        // Retornar imóveis disponíveis para o cliente
        return Ok(new { message = "Imóveis disponíveis" });
    }

    [HttpGet("favoritos")]
    public IActionResult GetFavoritos()
    {
        // Retornar imóveis favoritos do cliente
        return Ok(new { message = "Imóveis favoritos" });
    }

    [HttpPost("favorito/{imovelId}")]
    public IActionResult AdicionarFavorito(int imovelId)
    {
        // Adicionar imóvel aos favoritos
        return Ok(new { message = $"Imóvel {imovelId} adicionado aos favoritos" });
    }

    [HttpDelete("favorito/{imovelId}")]
    public IActionResult RemoverFavorito(int imovelId)
    {
        // Remover imóvel dos favoritos
        return Ok(new { message = $"Imóvel {imovelId} removido dos favoritos" });
    }

    [HttpGet("perfil")]
    public IActionResult GetPerfil()
    {
        // Retornar perfil do cliente
        return Ok(new { message = "Perfil do cliente" });
    }
}