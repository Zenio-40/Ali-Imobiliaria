using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb10_Tipologia;

public class RemoverTipologiaRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb10_tipologiaModel>
{
    public async Task<(tb10_tipologiaModel? dado, string mensagem, int codigo)> RemoverAsync(tb10_tipologiaModel model)
    {
        try
        {
            context.Tabela10Tipologia.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Tipologia removida com sucesso", 200) :
            (null, "Não foi possível remover a tipologia", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

