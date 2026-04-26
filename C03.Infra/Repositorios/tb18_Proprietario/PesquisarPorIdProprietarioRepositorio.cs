using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb18_Proprietario;

public class PesquisarPorIdProprietarioRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb18_proprietarioModel>
{
    public async Task<(tb18_proprietarioModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela18Proprietario.FindAsync(id);
            return entity != null ? (entity, "Proprietário encontrado", 200) :
            (null, "Proprietário não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
