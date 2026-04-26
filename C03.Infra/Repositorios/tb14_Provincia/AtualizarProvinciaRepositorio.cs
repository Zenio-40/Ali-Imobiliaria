using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb14_Provincia;

public class AtualizarProvinciaRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb14_provinciaModel>
{
    public async Task<(tb14_provinciaModel? dado, string mensagem, int codigo)> AtualizarAsync(tb14_provinciaModel model)
    {
        try
        {
            context.Tabela14Pronvincia.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Província atualizada com sucesso", 200) :
            (null, "Não foi possível atualizar a província", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

