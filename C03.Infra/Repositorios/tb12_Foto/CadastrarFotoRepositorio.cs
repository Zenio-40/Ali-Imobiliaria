using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb12_Foto;

public class CadastrarFotoRepositorio(CorretoraDbContext context) : ICadastrarRepositorio<tb12_fotoModel>
{
    public async Task<(tb12_fotoModel? dado, string mensagem, int codigo)> CadastrarAsync(tb12_fotoModel model)
    {
        try
        {
            await context.Tabela12Foto.AddAsync(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Foto cadastrada com sucesso", 201) :
            (null, "Não foi possível cadastrar a foto", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

