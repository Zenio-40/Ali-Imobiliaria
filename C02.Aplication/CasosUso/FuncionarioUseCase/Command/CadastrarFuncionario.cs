using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;

public class CadastrarFuncionario(ICadastrarRepositorio<tb04_funcionarioModel> _repositorio)
{
    public async Task<(object? dados, string mensagem, int codigo)> Executar(CadastrarFuncionarioDTO dto)
    {
        var senhaGerada = GerarSenhaAleatoria();
        var emailGerado = GerarEmail(dto.FuncionarioNome);
        var salt = GerarSalt();
        var senhaHash = GerarHash(senhaGerada, salt);

        var model = new tb04_funcionarioModel
        {
            Idtb02_perfilModel = dto.FuncionarioIdPerfil,
            Numero = dto.FuncionarioNumero,
            Nome = dto.FuncionarioNome,
            Estado = true,
            Email = new List<tb08_emailModel>
            {
                new() { Endereco = emailGerado }
            },
            Credencial = new List<tb05_credencial_acessoModel>
            {
                new()
                {
                    Senha_hash = senhaHash,
                    Senha_salt = salt
                }
            }
        };

        var (dado, mensagem, codigo) = await _repositorio.CadastrarAsync(model);

        if (codigo == 201)
        {
            return (new {
                dado!.Id,
                dado.Nome,
                Email = emailGerado,
                SenhaTemporaria = senhaGerada
            }, mensagem, codigo);
        }

        return (null, mensagem, codigo);
    }

    private static string GerarSenhaAleatoria()
    {
        var chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789@#!";
        var random = new Random();
        return new string(Enumerable.Range(0, 10)
            .Select(_ => chars[random.Next(chars.Length)]).ToArray());
    }

    private static string GerarSalt()
    {
        var bytes = new byte[16];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }

    private static string GerarHash(string senha, string salt)
    {
        var bytes = Encoding.UTF8.GetBytes(senha + salt);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    private static string GerarEmail(string nome)
    {
        var nomeFormatado = nome.ToLower()
            .Replace(" ", ".")
            .Replace("ã", "a").Replace("ç", "c")
            .Replace("é", "e").Replace("ê", "e")
            .Replace("á", "a").Replace("ó", "o");
        return $"{nomeFormatado}@aliimobiliaria.co.ao";
    }
}