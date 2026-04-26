using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb20_Solicitacao;

public class PesquisarPorIdSolicitacaoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb20_solicitacaoModel>
{
    public async Task<(tb20_solicitacaoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela20Solicitacao.FindAsync(id);
            return entity != null ? (entity, "Solicitação encontrada", 200) :
            (null, "Solicitação não encontrada", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
