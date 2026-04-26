using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using C02.Aplication.Servico;

namespace C03.Infra.Servico.PasswordService
{
    public class PasswordHashService : IPasswordHash
    {
        public Task<(string Hash, string Salt)> HashAsync(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, 100000, HashAlgorithmName.SHA512, 64);

            return Task.FromResult((Convert.ToBase64String(hash), Convert.ToBase64String(salt)));
        }
    }
}
