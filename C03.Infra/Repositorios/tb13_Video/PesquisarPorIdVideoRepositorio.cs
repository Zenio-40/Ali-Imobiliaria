using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb13_Video;

public class PesquisarPorIdVideoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb13_videoModel>
{
    public async Task<(tb13_videoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela13Video.FindAsync(id);
            return entity != null ? (entity, "Vídeo encontrado", 200) :
            (null, "Vídeo não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

