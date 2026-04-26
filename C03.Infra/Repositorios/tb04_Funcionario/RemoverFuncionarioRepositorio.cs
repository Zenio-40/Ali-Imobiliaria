using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb04_Funcionario;

public class RemoverFuncionarioRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb04_funcionarioModel>
{
    public async Task<(tb04_funcionarioModel? dado, string mensagem, int codigo)> RemoverAsync(tb04_funcionarioModel model)
    {
        try
        {
            context.Tabela04Funcinario.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Funcionario removido com sucesso", 200) :
            (null, "Não foi possível remover o funcionário", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}