using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb19_Estado_Solicitacao;

public class RemoverEstadoSolicitacaoRepositorio(CorretoraDbContext context) : IRemoverRepositorio<tb19_estado_solicitacaoModel>
{
    public async Task<(tb19_estado_solicitacaoModel? dado, string mensagem, int codigo)> RemoverAsync(tb19_estado_solicitacaoModel model)
    {
        try
        {
            context.Tabela19EstadoSolicitacao.Remove(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Estado de solicitação removido com sucesso", 200) :
            (null, "Não foi possível remover o estado de solicitação", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
