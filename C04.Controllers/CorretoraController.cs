using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CorretoraController : ControllerBase
{
    [HttpGet("dashboard")]
    public IActionResult GetDashboard()
    {
        // Retornar estatísticas da corretora
        return Ok(new { message = "Dashboard da Corretora" });
    }

    [HttpGet("imoveis")]
    public IActionResult GetImoveis()
    {
        // Listar imóveis para gestão
        return Ok(new { message = "Lista de imóveis" });
    }

    [HttpGet("clientes")]
    public IActionResult GetClientes()
    {
        // Listar clientes
        return Ok(new { message = "Lista de clientes" });
    }
}