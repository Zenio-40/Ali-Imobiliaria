using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;
using C02.Aplication.Servico;
using Microsoft.Extensions.Configuration;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;

public class CadastrarFuncionario(
    ICadastrarRepositorio<tb04_funcionarioModel> _repositorio, IPasswordCreate _passwordCreate, IPasswordHash _passwordHash,
    ISmsService _smsService,
    IConfiguration _configuration)
{
    public async Task<(object? dados, string mensagem, int codigo)> Executar(CadastrarFuncionarioDTO dto)
    {
        var senhaGerada = GerarSenhaAleatoria();
        var salt = GerarSalt();
        var senhaHash = GerarHash(senhaGerada, salt);

        var model = new tb04_funcionarioModel
{
    Idtb02_perfilModel = dto.FuncionarioIdPerfil,
    Numero = dto.FuncionarioTelefone,
    Nome = dto.FuncionarioNome,
    Estado = true,
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
            // Enviar credenciais por SMS
            var mensagemSmsCorpo = $"Bem-vindo à Ali Imobiliária! Suas credenciais de acesso: Telefone: {dto.FuncionarioTelefone} | Senha: {senhaGerada}";
            var nif = _configuration["Sms:Nif"] ?? "1000000000";
            var sucessoSms = await _smsService.SendSmsAsync(dto.FuncionarioTelefone, mensagemSmsCorpo, nif);

            return (null, "Funcionário cadastrado com sucesso!", codigo);
    
        }

        return (null, mensagem, codigo);
    }

    private static string GerarSenhaAleatoria()
    {
        var chars = "123456789";
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

   
}