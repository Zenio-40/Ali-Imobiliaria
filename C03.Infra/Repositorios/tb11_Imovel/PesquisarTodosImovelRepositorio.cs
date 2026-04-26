using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb11_Imovel;

public class PesquisarTodosImovelRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb11_imovelModel>
{
    public async Task<(IEnumerable<tb11_imovelModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela11Imovel
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Imóveis listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb11_imovelModel>(), ex.ToString(), 500);
        }
    }
}

