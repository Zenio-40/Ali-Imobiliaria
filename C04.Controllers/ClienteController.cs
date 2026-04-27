using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.Command;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.FavoritoUseCase.Command;
using Corretora.C02.Aplication.CasosUso.FavoritoUseCase.DTOs;
using Corretora.C02.Aplication.CasosUso.FavoritoUseCase.Queries;
using Corretora.C02.Aplication.CasosUso.ImovelUseCase.Queries;

namespace Corretora.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClienteController : ControllerBase
{
    private readonly CadastrarCliente _cadastrarCliente;
    private readonly ActualizarCliente _actualizarCliente;
    private readonly PesquisarClientePorId _pesquisarClientePorId;
    private readonly PesquisarTodosClientes _pesquisarTodosClientes;
    private readonly AdicionarFavorito _adicionarFavorito;
    private readonly RemoverFavorito _removerFavorito;
    private readonly ListarFavoritosDoCliente _listarFavoritos;
    private readonly PesquisarImoveisDisponiveis _pesquisarImoveisDisponiveis;

    public ClienteController(
        CadastrarCliente cadastrarCliente,
        ActualizarCliente actualizarCliente,
        PesquisarClientePorId pesquisarClientePorId,
        PesquisarTodosClientes pesquisarTodosClientes,
        AdicionarFavorito adicionarFavorito,
        RemoverFavorito removerFavorito,
        ListarFavoritosDoCliente listarFavoritos,
        PesquisarImoveisDisponiveis pesquisarImoveisDisponiveis)
    {
        _cadastrarCliente = cadastrarCliente;
        _actualizarCliente = actualizarCliente;
        _pesquisarClientePorId = pesquisarClientePorId;
        _pesquisarTodosClientes = pesquisarTodosClientes;
        _adicionarFavorito = adicionarFavorito;
        _removerFavorito = removerFavorito;
        _listarFavoritos = listarFavoritos;
        _pesquisarImoveisDisponiveis = pesquisarImoveisDisponiveis;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _cadastrarCliente.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPut]
    public async Task<IActionResult> Actualizar([FromBody] ActualizarClienteDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _actualizarCliente.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarTodosClientes.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id)
    {
        var (dados, mensagem, codigo) = await _pesquisarClientePorId.Executar(id);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("imoveis")]
    [AllowAnonymous]
    public async Task<IActionResult> GetImoveisDisponiveis([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var (dados, mensagem, codigo) = await _pesquisarImoveisDisponiveis.Executar(pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpGet("favoritos")]
    public async Task<IActionResult> GetFavoritos([FromQuery] int pagina = 1, [FromQuery] int quantidade = 20)
    {
        var idCliente = int.Parse(User.FindFirst("sub")?.Value ?? "0");
        var (dados, mensagem, codigo) = await _listarFavoritos.Executar(idCliente, pagina, quantidade);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpPost("favorito")]
    public async Task<IActionResult> AdicionarFavorito([FromBody] AdicionarFavoritoDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (dados, mensagem, codigo) = await _adicionarFavorito.Executar(dto);
        return StatusCode(codigo, new { dados, mensagem, codigo });
    }

    [HttpDelete("favorito/{id}")]
    public async Task<IActionResult> RemoverFavorito(int id)
    {
        var (sucesso, mensagem, codigo) = await _removerFavorito.Executar(id);
        return StatusCode(codigo, new { sucesso, mensagem, codigo });
    }

    [HttpGet("perfil")]
    public IActionResult GetPerfil()
    {
        return Ok(new { message = "Perfil do cliente" });
    }
}
