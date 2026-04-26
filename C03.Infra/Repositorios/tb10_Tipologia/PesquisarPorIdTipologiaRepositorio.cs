using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb10_Tipologia;

public class PesquisarPorIdTipologiaRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb10_tipologiaModel>
{
    public async Task<(tb10_tipologiaModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela10Tipologia.FindAsync(id);
            return entity != null ? (entity, "Tipologia encontrada", 200) :
            (null, "Tipologia não encontrada", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

