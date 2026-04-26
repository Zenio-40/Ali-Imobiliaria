using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb03_PerfilPermissao;

public class AtualizarPerfilPermissaoRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb03_perfiL_permissaoModel>
{
    public async Task<(tb03_perfiL_permissaoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb03_perfiL_permissaoModel model)
    {
        try
        {
            context.Tabela03PerfilPermissao.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Perfil permissão atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o perfil permissão", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

