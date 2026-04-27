using Corretora.C01.Domain;
using Corretora.C02.Aplication.CasosUso.ClienteUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.ClienteUseCase.Command;

public class CadastrarCliente(
    Corretora.C01.Domain.Interfaces.IPesquisarTodosRepositorio<tb06_clienteModel> pesquisarTodos,
    Corretora.C01.Domain.Interfaces.ICadastrarRepositorio<tb06_clienteModel> cadastrar)
{
    public async Task<(CadastrarClienteDTO? dados, string mensagem, int codigo)> Executar(CadastrarClienteDTO dto)
    {
        var (todos, _, _) = await pesquisarTodos.PesquisarTodosAsync(1, 1000);
        var clienteExistente = todos?.FirstOrDefault(c => c.Telefone.Any(t => t.Numero == dto.ClienteTelefone));
        if (clienteExistente is not null)
            return (null, "Cliente com este telefone já existe", 409);

        var model = new tb06_clienteModel
        {
            Nome = dto.ClienteNome,
            Idtb02_perfilModel = dto.ClienteIdPerfil,
            Telefone = new List<tb07_telefoneModel>
            {
                new tb07_telefoneModel
                {
                    Numero = dto.ClienteTelefone
                }
            },
            Email = new List<tb08_emailModel>
            {
                new tb08_emailModel
                {
                    email = dto.ClienteEmail
                }
            }
        };

        var (dado, mensagem, codigo) = await cadastrar.CadastrarAsync(model);
        return dado is null
            ? (null, mensagem, codigo)
            : (dto, mensagem, codigo);
    }
}

