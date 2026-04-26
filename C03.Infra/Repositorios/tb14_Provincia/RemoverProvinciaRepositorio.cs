using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb14_Provincia;

public class RemoverProvinciaRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb14_provinciaModel>
{
    public async Task<(tb14_provinciaModel? dado, string mensagem, int codigo)> RemoverAsync(tb14_provinciaModel model)
    {
        try
        {
            context.Tabela14Pronvincia.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Província removida com sucesso", 200) :
            (null, "Não foi possível remover a província", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

