using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb08_Email;

public class PesquisarPorIdEmailRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb08_emailModel>
{
    public async Task<(tb08_emailModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela08Email.FindAsync(id);
            return entity != null ? (entity, "Email encontrado", 200) :
            (null, "Email não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

