using System;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C03.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Repositorios.E06_cliente;

public class PesquisarPorIdClienteRepositorio(CorretoraDbContext context) : IPesquisarPorIdRepositorio<tb06_clienteModel>
{
    public async Task<(tb06_clienteModel? dado, string mensagem, int codigo)> PesquisarPorIdAsync(int id, int pagina = 1, int quantidade = 20)
    {
        try
        {
            var cliente = await context.Tabela06Cliente.FindAsync(id);
            return cliente is not null ?
                (cliente, "Cliente encontrado com sucesso!", 200) :
                (null, "Cliente não encontrado.", 404);
        }
        catch (Exception ex)
        {
            return (null, ex.ToString(), 500);
        }
    }
}
