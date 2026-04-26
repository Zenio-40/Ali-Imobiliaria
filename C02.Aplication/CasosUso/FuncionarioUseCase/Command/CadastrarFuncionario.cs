using System;
using System.Collections.Generic;
using C02.Aplication.Servico;
using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;

public class CadastrarFuncionario (IPesquisarTelefoneRepositorio<tb04_funcionarioModel> pesquisar, ICadastrarRepositorio<tb04_funcionarioModel> cadastrar, IPasswordCreate gerarSenha, IPasswordHash criptoSenha, ISmsService sms)
    {
    public async Task<(CadastrarFuncionarioDTO? dados, string mensagem, int codigo)> Executar(CadastrarFuncionarioDTO dto)
    {
        var usuario = await pesquisar.PesquisarAsync(dto.FuncionarioTelefone);
        if (usuario is not null) return (null, "Funcionario que quer cadastrar já existe", 409);

        string senha = await gerarSenha.GenerateAsync();
        var (senhaHash, saltHash) = await criptoSenha.HashAsync(senha);

        var model = new tb04_funcionarioModel
        {
            Nome = dto.FuncionarioNome,
            Idtb02_perfilModel = dto.FuncionarioIdPerfil,
            Telefone = new List<tb07_telefoneModel>
            {
                new tb07_telefoneModel
                {
                    Numero = dto.FuncionarioTelefone
                }
            },
            Credencial = new List<tb05_credencial_acessoModel>
            {
                new tb05_credencial_acessoModel
                {
                    Senha_hash = senhaHash,
                    Senha_salt = saltHash
                }
            }
        };

        var (dado, mensagem, codigo) = await cadastrar.CadastrarAsync(model);
        if (dado is null)
            return (null, mensagem, codigo);
        
        string texto = $"Bem-vindo(a) à equipe, {model.Nome}! Sua conta foi criada com sucesso. acesse o sistema a partir do link : www.aliimobiliaria.com/login, utilizando o numero de telefone : {dto.FuncionarioTelefone} e a senha {senha}";

        var smsResponse = await sms.SendSmsAsync(dto.FuncionarioTelefone, texto, "101034904950");

        return (dto, mensagem, codigo); 
    }
}