using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb17_Endereco;

public class CadastrarEnderecoRepositorio(CorretoraDbContext context) : ICadastrarRepositorio<tb17_enderecoModel>
{
    public async Task<(tb17_enderecoModel? dado, string mensagem, int codigo)> CadastrarAsync(tb17_enderecoModel model)
    {
        try
        {
            await context.Tabela17Enderco.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Endereço cadastrado com sucesso", 201) :
            (null, "Não foi possível cadastrar o endereço", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

