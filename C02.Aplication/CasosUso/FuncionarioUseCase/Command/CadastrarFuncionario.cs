using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;

public class CadastrarFuncionario(
    IPesquisarTelefoneRepositorio<tb04_funcionarioModel> pesquisar,
    ICadastrarRepositorio<tb04_funcionarioModel> cadastrar)
{
    public async Task<(CadastrarFuncionarioDTO? dados, string mensagem, int codigo)> Executar(CadastrarFuncionarioDTO dto)
    {
        var model = new tb04_funcionarioModel
        {
            Nome = dto.FuncionarioNome,
            Telefone = dto.FuncionarioTelefone,
            Perfil = dto.FuncionarioIdPerfil

        };

        var (dado, mensagem, codigo) = await cadastrar.CadastrarAsync(model);
    }
}
