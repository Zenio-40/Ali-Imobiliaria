using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb15_municipio;

public class PesquisarPorTextoMunicipioRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb15_municipioModel>
{
    public async Task<(IEnumerable<tb15_municipioModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela15Municipio.Where(m => m.Nome.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Municípios encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb15_municipioModel>(), ex.ToString(), 500);
        }
    }
}

