using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb11_Imovel;

public class CadastrarImovelRepositorio(CorretoraDbContext context) : ICadastrarRepositorio<tb11_imovelModel>
{
    public async Task<(tb11_imovelModel? dado, string mensagem, int codigo)> CadastrarAsync(tb11_imovelModel model)
    {
        try
        {
            await context.Tabela11Imovel.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Imóvel cadastrado com sucesso", 201) :
            (null, "Não foi possível cadastrar o imóvel", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

