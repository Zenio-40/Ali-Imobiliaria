using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using C02.Aplication.Servico;

namespace C03.Infra.Servico.PasswordService
{
    public class PasswordVerifyService : IPasswordVerify
    {
        public Task<bool> VerifyAsync(string senha, string hashArmazenado, string saltArmazenado)
        {
            byte[] salt = Convert.FromBase64String(saltArmazenado);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, 100000, HashAlgorithmName.SHA512, 64);

            return Task.FromResult(Convert.ToBase64String(hash) == hashArmazenado);
        }
    }
}
