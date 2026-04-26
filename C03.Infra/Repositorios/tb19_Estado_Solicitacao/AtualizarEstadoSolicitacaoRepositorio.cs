using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb19_Estado_Solicitacao;

public class AtualizarEstadoSolicitacaoRepositorio(CorretoraDbContext context) : IAtualizarRepositorio<tb19_estado_solicitacaoModel>
{
    public async Task<(tb19_estado_solicitacaoModel? dado, string mensagem, int codigo)> AtualizarAsync(tb19_estado_solicitacaoModel model)
    {
        try
        {
            context.Tabela19EstadoSolicitacao.Update(model);
            return await context.SaveChangesAsync() > 0 ? (model, "Estado de solicitação atualizado com sucesso", 200) :
            (null, "Não foi possível atualizar o estado de solicitação", 500);
        }
        catch (DbUpdateException ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
