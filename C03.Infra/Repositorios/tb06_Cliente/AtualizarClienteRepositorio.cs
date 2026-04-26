using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb06_Cliente;

public class AtualizarClienteRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb06_clienteModel>
{
    public async Task<(tb06_clienteModel? dado, string mensagem, int codigo)> AtualizarAsync(tb06_clienteModel model)
    {
        try
        {
            context.Tabela06Cliente.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Cliente atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o cliente", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

