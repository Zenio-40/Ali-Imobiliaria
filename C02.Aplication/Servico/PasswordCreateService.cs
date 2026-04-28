using System;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class PasswordCreateService : IPasswordCreate
    {
        public async Task<string> GenerateAsync() =>
            new Random().NextInt64(100000, 999999).ToString();
    }
}
