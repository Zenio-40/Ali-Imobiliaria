using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
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