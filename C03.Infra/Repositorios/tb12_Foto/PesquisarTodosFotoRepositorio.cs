using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb12_Foto;

public class PesquisarTodosFotoRepositorio(CorretoraDbContext context) : IPesquisarTodosRepositorios<tb12_fotoModel>
{
    public async Task<(IEnumerable<tb12_fotoModel> dados, string mensagem, int codigo)> PesquisarTodosAsync(int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela12Foto
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Fotos listadas com sucesso", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb12_fotoModel>(), ex.ToString(), 500);
        }
    }
}

