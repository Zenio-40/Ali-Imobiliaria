using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interface;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.tb17_Endereco;

public class PesquisarPorIdEnderecoRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb17_enderecoModel>
{
    public async Task<(tb17_enderecoModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var entity = await context.Tabela17Enderco.FindAsync(id);
            return entity != null ? (entity, "Endereço encontrado", 200) :
            (null, "Endereço não encontrado", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}

