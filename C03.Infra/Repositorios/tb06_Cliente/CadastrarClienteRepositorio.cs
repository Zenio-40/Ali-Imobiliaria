using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb06_Cliente;

public class CadastrarClienteRepositorio(CorretoraDbContext context) : ICadastrarRepositorio<tb06_clienteModel>
{
    public async Task<(tb06_clienteModel? dado, string mensagem, int codigo)> CadastrarAsync(tb06_clienteModel model)
    {
        try
        {
            await context.Tabela06Cliente.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Cliente cadastrado com sucesso", 201) :
            (null, "Não foi possível cadastrar o cliente", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

