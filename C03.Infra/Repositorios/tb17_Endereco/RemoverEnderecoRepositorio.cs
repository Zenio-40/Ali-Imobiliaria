using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb17_Endereco;

public class RemoverEnderecoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb17_enderecoModel>
{
    public async Task<(tb17_enderecoModel? dado, string mensagem, int codigo)> RemoverAsync(tb17_enderecoModel model)
    {
        try
        {
            context.Tabela17Enderco.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Endereço removido com sucesso", 200) :
            (null, "Não foi possível remover o endereço", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

