using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb09_tipo_imovel;

public class PesquisarTodosTipoImovelRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb09_tipo_imovelModel>
{
    public async Task<(IEnumerable<tb09_tipo_imovelModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela09TipolaImovel
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Tipos de imóveis listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb09_tipo_imovelModel>(), ex.ToString(), 500);
        }
    }
}

