using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb19_Estado_Solicitacao;

public class PesquisarTodosEstadoSolicitacaoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb19_estado_solicitacaoModel>
{
    public async Task<(IEnumerable<tb19_estado_solicitacaoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela19EstadoSolicitacao
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Estados de solicitação listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb19_estado_solicitacaoModel>(), ex.ToString(), 500);
        }
    }
}
