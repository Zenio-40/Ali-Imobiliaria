using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb08_Email;

public class RemoverEmailRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb08_emailModel>
{
    public async Task<(tb08_emailModel? dado, string mensagem, int codigo)> RemoverAsync(tb08_emailModel model)
    {
        try
        {
            context.Tabela08Email.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Email removido com sucesso", 200) :
            (null, "Não foi possível remover o email", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

