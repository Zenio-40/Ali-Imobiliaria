using System;
using System.Threading.Tasks;
using C02.Aplication.Servico;

namespace C03.Infra.Servico.PasswordService
{
    public class PasswordCreateService : IPasswordCreate
    {
        public Task<string> GenerateAsync() =>
            Task.FromResult(new Random().NextInt64(100000, 999999).ToString());
    }
}
