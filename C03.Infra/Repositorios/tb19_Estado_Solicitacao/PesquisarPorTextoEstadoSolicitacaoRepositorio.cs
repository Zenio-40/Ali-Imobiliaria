using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb19_Estado_Solicitacao;

public class PesquisarPorTextoEstadoSolicitacaoRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb19_estado_solicitacaoModel>
{
    public async Task<(IEnumerable<tb19_estado_solicitacaoModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela19EstadoSolicitacao.Where(e => e.Nome.Contains(texto) || e.Descricao.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Estados de solicitação encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb19_estado_solicitacaoModel>(), ex.ToString(), 500);
        }
    }
}
