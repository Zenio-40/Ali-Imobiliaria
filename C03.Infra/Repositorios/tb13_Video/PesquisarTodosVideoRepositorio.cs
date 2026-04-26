using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb13_Video;

public class PesquisarTodosVideoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb13_videoModel>
{
    public async Task<(IEnumerable<tb13_videoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela13Video
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Vídeos listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb13_videoModel>(), ex.ToString(), 500);
        }
    }
}

