using System;
using System.Linq;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb02_Perfil;

public class PesquisarPorTextoPerfilRepositorio(CorretoraDbContext context) : IPesquisarPorTextoRepositorio<tb02_perfilModel>
{
    public async Task<(IEnumerable<tb02_perfilModel> dados, string mensagem, int codigo)> PesquisarPorTextoAsync(string texto, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entities = await context.Tabela02Perfil.Where(p => p.Descricao.Contains(texto))
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();
            return (entities, "Perfis encontrados", 200);
        }
        catch (Exception ex)
        {
            return (new List<tb02_perfilModel>(), ex.ToString(), 500);
        }
    }
}

