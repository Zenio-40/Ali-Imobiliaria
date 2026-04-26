using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb08_Email;

public class AtualizarEmailRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb08_emailModel>
{
    public async Task<(tb08_emailModel? dado, string mensagem, int codigo)> AtualizarAsync(tb08_emailModel model)
    {
        try
        {
            context.Tabela08Email.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Email atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o email", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

