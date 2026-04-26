using Corretora.C01.Domain;
using Corretora.C01.Domain.Interfaces;
using Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;
using Corretora.C03.Infra.Repositorios.E04_funcionario;
using C02.Aplication.Servico;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.Command;

public class LoginCommand(ILoginRepositorio loginRepositorio, IPasswordVerify passwordVerify, IJwtService jwtService)
{
    public async Task<(string? token, string mensagem, int codigo)> Executar(LoginDTO dto)
    {
        var usuario = await loginRepositorio.BuscarPorTelefoneAsync(dto.Telefone);
        if (usuario == null || !usuario.Credencial.Any())
        {
            return (null, "Usuário não encontrado", 404);
        }

        var credencial = usuario.Credencial.First();
        bool senhaValida = await passwordVerify.VerifyAsync(dto.Senha, credencial.Senha_hash, credencial.Senha_salt);
        if (!senhaValida)
        {
            return (null, "Senha inválida", 401);
        }

        string token = jwtService.GenerateToken(usuario.Id.ToString(), usuario.Perfil?.Descricao ?? "Funcionario");
        return (token, "Login realizado com sucesso", 200);
    }
}