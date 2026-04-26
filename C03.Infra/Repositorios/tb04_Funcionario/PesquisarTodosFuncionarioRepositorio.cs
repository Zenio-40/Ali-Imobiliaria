using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb04_Funcionario;

public class PesquisarTodosFuncionarioRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb04_funcionarioModel>
{
    public async Task<(IEnumerable<tb04_funcionarioModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela04Funcinario
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Funcionarios listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb04_funcionarioModel>(), ex.ToString(), 500);
        }
    }
}