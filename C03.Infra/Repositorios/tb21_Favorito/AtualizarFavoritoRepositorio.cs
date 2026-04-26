using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb21_Favorito;

public class AtualizarFavoritoRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb21_favoritoModel>
{
    public async Task<(tb21_favoritoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb21_favoritoModel model)
    {
        try
        {
            context.Tabela21Favorito.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Favorito atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o favorito", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
