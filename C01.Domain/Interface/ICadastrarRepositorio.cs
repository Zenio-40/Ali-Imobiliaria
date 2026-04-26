using System;

namespace Corretora.C01.Domain.Interface;

public interface ICadastrarRepositorio<T>
{
    Task<(T? dado, string mensagem, int codigo)> CadastrarAsync(T model);
}