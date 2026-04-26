using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb02_Perfil;

public class PesquisarPorIdPerfilRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb02_perfilModel>
{
    public async Task<(tb02_perfilModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela02Perfil.FindAsync(id);
            return entity != null ? (entity, "Perfil encontrado", 200) :
            (null, "Perfil não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

