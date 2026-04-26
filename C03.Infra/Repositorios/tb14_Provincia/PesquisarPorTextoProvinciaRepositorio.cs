using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb14_Provincia;

public class PesquisarPorTextoProvinciaRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb14_provinciaModel>
{
    public async Task<(IEnumerable<tb14_provinciaModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela14Pronvincia.Where(p => p.Nome.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Províncias encontradas", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb14_provinciaModel>(), ex.ToString(), 500);
        }
    }
}

