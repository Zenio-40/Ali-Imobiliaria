using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class PasswordVerifyService : IPasswordVerify
    {
        public Task<bool> VerifyAsync(string senha, string hashArmazenado, string saltArmazenado)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = Encoding.UTF8.GetBytes(senha + saltArmazenado);
                var hashBytes = sha256.ComputeHash(saltedPassword);
                var hashCalculado = Convert.ToBase64String(hashBytes);
                return Task.FromResult(hashCalculado == hashArmazenado);
            }
        }
    }
}