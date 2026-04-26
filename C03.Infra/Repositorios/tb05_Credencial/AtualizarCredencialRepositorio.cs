using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb05_Credencial;

public class AtualizarCredencialRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb05_credencial_acessoModel>
{
    public async Task<(tb05_credencial_acessoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb05_credencial_acessoModel model)
    {
        try
        {
            context.Tabela05Credencial.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Credencial atualizada com sucesso", 200) :
            (null, "Não foi possível atualizar a credencial", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

