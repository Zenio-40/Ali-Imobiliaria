using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb10_Tipologia;

public class PesquisarPorTextoTipologiaRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb10_tipologiaModel>
{
    public async Task<(IEnumerable<tb10_tipologiaModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela10Tipologia.Where(t => t.Descricao.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Tipologias encontradas", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb10_tipologiaModel>(), ex.ToString(), 500);
        }
    }
}

