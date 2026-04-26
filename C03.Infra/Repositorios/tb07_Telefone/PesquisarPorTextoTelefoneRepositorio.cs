using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb07_Telefone;

public class PesquisarPorTextoTelefoneRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb07_telefoneModel>
{
    public async Task<(IEnumerable<tb07_telefoneModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela07Telefone.Where(t => t.Numero.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Telefones encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb07_telefoneModel>(), ex.ToString(), 500);
        }
    }
}

