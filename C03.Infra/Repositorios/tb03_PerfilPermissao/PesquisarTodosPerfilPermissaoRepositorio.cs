using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb03_PerfilPermissao;

public class PesquisarTodosPerfilPermissaoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb03_perfiL_permissaoModel>
{
    public async Task<(IEnumerable<tb03_perfiL_permissaoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela03PerfilPermissao
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Perfis permissões listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb03_perfiL_permissaoModel>(), ex.ToString(), 500);
        }
    }
}

