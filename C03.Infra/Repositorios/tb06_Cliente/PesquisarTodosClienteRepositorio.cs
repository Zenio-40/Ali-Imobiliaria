using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb06_Cliente;

public class PesquisarTodosClienteRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb06_clienteModel>
{
    public async Task<(IEnumerable<tb06_clienteModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela06Cliente
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Clientes listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb06_clienteModel>(), ex.ToString(), 500);
        }
    }
}

