using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class PasswordCreateService : IPasswordCreate
    {
        public Task<string> GenerateAsync()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            var password = new char[8];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return Task.FromResult(new string(password));
        }
    }
}