using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb20_Solicitacao;

public class RemoverSolicitacaoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb20_solicitacaoModel>
{
    public async Task<(tb20_solicitacaoModel? dado, string mensagem, int codigo)> RemoverAsync(tb20_solicitacaoModel model)
    {
        try
        {
            context.Tabela20Solicitacao.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Solicitação removida com sucesso", 200) :
            (null, "Não foi possível remover a solicitação", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
