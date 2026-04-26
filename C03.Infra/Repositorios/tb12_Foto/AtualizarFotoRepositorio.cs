using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb12_Foto;

public class AtualizarFotoRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb12_fotoModel>
{
    public async Task<(tb12_fotoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb12_fotoModel model)
    {
        try
        {
            context.Tabela12Foto.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Foto atualizada com sucesso", 200) :
            (null, "Não foi possível atualizar a foto", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

