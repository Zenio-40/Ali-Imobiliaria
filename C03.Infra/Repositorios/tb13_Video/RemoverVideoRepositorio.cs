using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb13_Video;

public class RemoverVideoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb13_videoModel>
{
    public async Task<(tb13_videoModel? dado, string mensagem, int codigo)> RemoverAsync(tb13_videoModel model)
    {
        try
        {
            context.Tabela13Video.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Vídeo removido com sucesso", 200) :
            (null, "Não foi possível remover o vídeo", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

