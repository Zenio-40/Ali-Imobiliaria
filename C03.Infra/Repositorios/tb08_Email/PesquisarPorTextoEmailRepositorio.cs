using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb08_Email;

public class PesquisarPorTextoEmailRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb08_emailModel>
{
    public async Task<(IEnumerable<tb08_emailModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela08Email.Where(e => e.email.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Emails encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb08_emailModel>(), ex.ToString(), 500);
        }
    }
}

