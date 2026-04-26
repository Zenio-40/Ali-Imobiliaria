using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb02_Perfil;

public class CadastrarPerfilRepositorio(CorretoraDbContext context) : ICadastrarRepositorio<tb02_perfilModel>
{
    public async Task<(tb02_perfilModel? dado, string mensagem, int codigo)> CadastrarAsync(tb02_perfilModel model)
    {
        try
        {
            await context.Tabela02Perfil.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Perfil cadastrado com sucesso", 201) :
            (null, "Não foi possível cadastrar o perfil", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

