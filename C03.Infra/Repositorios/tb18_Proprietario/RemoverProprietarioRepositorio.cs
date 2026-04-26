using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb18_Proprietario;

public class RemoverProprietarioRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb18_proprietarioModel>
{
    public async Task<(tb18_proprietarioModel? dado, string mensagem, int codigo)> RemoverAsync(tb18_proprietarioModel model)
    {
        try
        {
            context.Tabela18Proprietario.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Proprietário removido com sucesso", 200) :
            (null, "Não foi possível remover o proprietário", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
