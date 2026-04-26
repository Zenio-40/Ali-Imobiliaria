using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb17_Endereco;

public class PesquisarPorTextoEnderecoRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb17_enderecoModel>
{
    public async Task<(IEnumerable<tb17_enderecoModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela17Enderco.Where(e => e.Nome.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Endereços encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb17_enderecoModel>(), ex.ToString(), 500);
        }
    }
}

