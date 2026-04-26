using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb11_Imovel;

public class RemoverImovelRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb11_imovelModel>
{
    public async Task<(tb11_imovelModel? dado, string mensagem, int codigo)> RemoverAsync(tb11_imovelModel model)
    {
        try
        {
            context.Tabela11Imovel.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Imóvel removido com sucesso", 200) :
            (null, "Não foi possível remover o imóvel", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

