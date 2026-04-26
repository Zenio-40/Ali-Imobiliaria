using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb21_Favorito;

public class PesquisarTodosFavoritoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb21_favoritoModel>
{
    public async Task<(IEnumerable<tb21_favoritoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela21Favorito
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Favoritos listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb21_favoritoModel>(), ex.ToString(), 500);
        }
    }
}
