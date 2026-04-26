using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb10_Tipologia;

public class PesquisarTodosTipologiaRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb10_tipologiaModel>
{
    public async Task<(IEnumerable<tb10_tipologiaModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela10Tipologia
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Tipologias listadas com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb10_tipologiaModel>(), ex.ToString(), 500);
        }
    }
}

