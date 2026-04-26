using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb05_Credencial;

public class RemoverCredencialRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb05_credencial_acessoModel>
{
    public async Task<(tb05_credencial_acessoModel? dado, string mensagem, int codigo)> RemoverAsync(tb05_credencial_acessoModel model)
    {
        try
        {
            context.Tabela05Credencial.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Credencial removida com sucesso", 200) :
            (null, "Não foi possível remover a credencial", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

