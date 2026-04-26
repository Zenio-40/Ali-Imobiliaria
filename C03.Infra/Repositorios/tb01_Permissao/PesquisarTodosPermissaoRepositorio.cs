using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb01_Permissao;

public class PesquisarTodosPermissaoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb01_permissaoModel>
{
    public async Task<(IEnumerable<tb01_permissaoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela01Permissao
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Permissões listadas com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb01_permissaoModel>(), ex.ToString(), 500);
        }
    }
}

