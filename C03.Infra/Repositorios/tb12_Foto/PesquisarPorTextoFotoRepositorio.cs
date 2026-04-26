using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb12_Foto;

public class PesquisarPorTextoFotoRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb12_fotoModel>
{
    public async Task<(IEnumerable<tb12_fotoModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela12Foto.Where(f => f.Foto.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Fotos encontradas", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb12_fotoModel>(), ex.ToString(), 500);
        }
    }
}

