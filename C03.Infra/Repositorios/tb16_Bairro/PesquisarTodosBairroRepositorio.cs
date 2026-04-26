using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb16_Bairro;

public class PesquisarTodosBairroRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb16_bairroModel>
{
    public async Task<(IEnumerable<tb16_bairroModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela16Bairro
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Bairros listados com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb16_bairroModel>(), ex.ToString(), 500);
        }
    }
}

