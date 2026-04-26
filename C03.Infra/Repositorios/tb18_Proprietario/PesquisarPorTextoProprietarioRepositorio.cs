using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb18_Proprietario;

public class PesquisarPorTextoProprietarioRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb18_proprietarioModel>
{
    public async Task<(IEnumerable<tb18_proprietarioModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela18Proprietario.Where(p => p.Nome.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Proprietários encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb18_proprietarioModel>(), ex.ToString(), 500);
        }
    }
}
