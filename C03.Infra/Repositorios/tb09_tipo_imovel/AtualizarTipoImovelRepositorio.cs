using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb09_tipo_imovel;

public class AtualizarTipoImovelRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb09_tipo_imovelModel>
{
    public async Task<(tb09_tipo_imovelModel? dado, string mensagem, int codigo)> AtualizarAsync(tb09_tipo_imovelModel model)
    {
        try
        {
            context.Tabela09TipolaImovel.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Tipo de imóvel atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o tipo de imóvel", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

