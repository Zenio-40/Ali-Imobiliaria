using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class PasswordHashService : IPasswordHash
    {
        public async Task<(string Hash, string Salt)> HashAsync(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, 100000, HashAlgorithmName.SHA512, 64);
            return await Task.FromResult((Convert.ToBase64String(hash), Convert.ToBase64String(salt)));
        }
    }
}
