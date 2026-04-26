using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb01_Permissao;

public class PesquisarPorIdPermissaoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb01_permissaoModel>
{
    public async Task<(tb01_permissaoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela01Permissao.FindAsync(id);
            return entity != null ? (entity, "Permissão encontrada", 200) :
            (null, "Permissão não encontrada", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

