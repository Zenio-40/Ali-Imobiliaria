using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb02_Perfil;

public class RemoverPerfilRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb02_perfilModel>
{
    public async Task<(tb02_perfilModel? dado, string mensagem, int codigo)> RemoverAsync(tb02_perfilModel model)
    {
        try
        {
            context.Tabela02Perfil.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Perfil removido com sucesso", 200) :
            (null, "Não foi possível remover o perfil", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

