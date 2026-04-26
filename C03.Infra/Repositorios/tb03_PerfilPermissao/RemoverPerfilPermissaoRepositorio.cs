using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb03_PerfilPermissao;

public class RemoverPerfilPermissaoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb03_perfiL_permissaoModel>
{
    public async Task<(tb03_perfiL_permissaoModel? dado, string mensagem, int codigo)> RemoverAsync(tb03_perfiL_permissaoModel model)
    {
        try
        {
            context.Tabela03PerfilPermissao.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Perfil permissão removido com sucesso", 200) :
            (null, "Não foi possível remover o perfil permissão", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

