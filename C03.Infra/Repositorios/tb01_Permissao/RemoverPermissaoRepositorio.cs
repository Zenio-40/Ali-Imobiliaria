using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb01_Permissao;

public class RemoverPermissaoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb01_permissaoModel>
{
    public async Task<(tb01_permissaoModel? dado, string mensagem, int codigo)> RemoverAsync(tb01_permissaoModel model)
    {
        try
        {
            context.Tabela01Permissao.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Permissão removida com sucesso", 200) :
            (null, "Não foi possível remover a permissão", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

