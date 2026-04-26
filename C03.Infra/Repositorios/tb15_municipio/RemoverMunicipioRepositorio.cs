using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb15_municipio;

public class RemoverMunicipioRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb15_municipioModel>
{
    public async Task<(tb15_municipioModel? dado, string mensagem, int codigo)> RemoverAsync(tb15_municipioModel model)
    {
        try
        {
            context.Tabela15Municipio.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Município removido com sucesso", 200) :
            (null, "Não foi possível remover o município", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

