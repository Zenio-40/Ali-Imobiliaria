using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb13_Video;

public class PesquisarPorTextoVideoRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb13_videoModel>
{
    public async Task<(IEnumerable<tb13_videoModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela13Video.Where(v => v.Video.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Vídeos encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb13_videoModel>(), ex.ToString(), 500);
        }
    }
}

