using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class PasswordHashService : IPasswordHash
    {
        public Task<(string Hash, string Salt)> HashAsync(string senha)
        {
            var saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            var salt = Convert.ToBase64String(saltBytes);

            string hash;
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = Encoding.UTF8.GetBytes(senha + salt);
                var hashBytes = sha256.ComputeHash(saltedPassword);
                hash = Convert.ToBase64String(hashBytes);
            }

            return Task.FromResult((hash, salt));
        }
    }
}