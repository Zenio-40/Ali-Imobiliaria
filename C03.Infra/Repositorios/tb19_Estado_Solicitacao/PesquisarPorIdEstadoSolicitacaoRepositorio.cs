using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb19_Estado_Solicitacao;

public class PesquisarPorIdEstadoSolicitacaoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb19_estado_solicitacaoModel>
{
    public async Task<(tb19_estado_solicitacaoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela19EstadoSolicitacao.FindAsync(id);
            return entity != null ? (entity, "Estado de solicitação encontrado", 200) :
            (null, "Estado de solicitação não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
