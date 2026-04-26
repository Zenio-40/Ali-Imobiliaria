using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb04_Funcionario;

public class AtualizarFuncionarioRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb04_funcionarioModel>
{
    public async Task<(tb04_funcionarioModel? dado, string mensagem, int codigo)> AtualizarAsync(tb04_funcionarioModel model)
    {
        try
        {
            context.Tabela04Funcinario.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Funcionario atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o funcionário", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}