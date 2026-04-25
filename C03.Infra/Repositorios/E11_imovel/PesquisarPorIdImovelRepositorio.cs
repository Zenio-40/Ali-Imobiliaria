using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.E11_imovel;

public class PesquisarPorIdImovelRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb11_imovelModel>
{
    public async Task<(tb11_imovelModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var imovel = await context.Tabela11Imovel.FindAsync(id);
            return imovel is not null ?
                (imovel, "Imóvel encontrado com sucesso!", 200) :
                (null, "Imóvel não encontrado.", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
