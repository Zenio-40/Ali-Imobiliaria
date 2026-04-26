using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb20_Solicitacao;

public class PesquisarTodosSolicitacaoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb20_solicitacaoModel>
{
    public async Task<(IEnumerable<tb20_solicitacaoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela20Solicitacao
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Solicitações listadas com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb20_solicitacaoModel>(), ex.ToString(), 500);
        }
    }
}
