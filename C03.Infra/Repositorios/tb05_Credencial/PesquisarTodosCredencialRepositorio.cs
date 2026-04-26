using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb05_Credencial;

public class PesquisarTodosCredencialRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb05_credencial_acessoModel>
{
    public async Task<(IEnumerable<tb05_credencial_acessoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela05Credencial
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Credenciais listadas com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb05_credencial_acessoModel>(), ex.ToString(), 500);
        }
    }
}

