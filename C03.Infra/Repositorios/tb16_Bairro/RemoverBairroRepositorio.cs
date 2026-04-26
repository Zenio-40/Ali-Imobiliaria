using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb16_Bairro;

public class RemoverBairroRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb16_bairroModel>
{
    public async Task<(tb16_bairroModel? dado, string mensagem, int codigo)> RemoverAsync(tb16_bairroModel model)
    {
        try
        {
            context.Tabela16Bairro.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Bairro removido com sucesso", 200) :
            (null, "Não foi possível remover o bairro", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

