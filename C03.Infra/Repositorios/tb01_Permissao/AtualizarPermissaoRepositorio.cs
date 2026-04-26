using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb01_Permissao;

public class AtualizarPermissaoRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb01_permissaoModel>
{
    public async Task<(tb01_permissaoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb01_permissaoModel model)
    {
        try
        {
            context.Tabela01Permissao.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Permissão atualizada com sucesso", 200) :
            (null, "Não foi possível atualizar a permissão", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

