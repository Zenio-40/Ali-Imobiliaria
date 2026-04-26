using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb07_Telefone;

public class RemoverTelefoneRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb07_telefoneModel>
{
    public async Task<(tb07_telefoneModel? dado, string mensagem, int codigo)> RemoverAsync(tb07_telefoneModel model)
    {
        try
        {
            context.Tabela07Telefone.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Telefone removido com sucesso", 200) :
            (null, "Não foi possível remover o telefone", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

