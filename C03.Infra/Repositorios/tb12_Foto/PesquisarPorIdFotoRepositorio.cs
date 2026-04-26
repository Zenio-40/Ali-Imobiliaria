using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb12_Foto;

public class PesquisarPorIdFotoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb12_fotoModel>
{
    public async Task<(tb12_fotoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela12Foto.FindAsync(id);
            return entity != null ? (entity, "Foto encontrada", 200) :
            (null, "Foto não encontrada", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

