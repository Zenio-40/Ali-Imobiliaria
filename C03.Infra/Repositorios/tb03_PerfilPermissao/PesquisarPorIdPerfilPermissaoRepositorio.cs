using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb03_PerfilPermissao;

public class PesquisarPorIdPerfilPermissaoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb03_perfiL_permissaoModel>
{
    public async Task<(tb03_perfiL_permissaoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela03PerfilPermissao.FindAsync(id);
            return entity != null ? (entity, "Perfil permissão encontrado", 200) :
            (null, "Perfil permissão não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

