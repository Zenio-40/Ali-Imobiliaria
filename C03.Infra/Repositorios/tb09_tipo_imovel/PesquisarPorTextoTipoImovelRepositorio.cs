using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb09_tipo_imovel;

public class PesquisarPorTextoTipoImovelRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb09_tipo_imovelModel>
{
    public async Task<(IEnumerable<tb09_tipo_imovelModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela09TipolaImovel.Where(t => t.Descricao.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Tipos de imóveis encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb09_tipo_imovelModel>(), ex.ToString(), 500);
        }
    }
}

