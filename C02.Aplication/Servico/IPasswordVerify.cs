using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public interface IPasswordVerify
    {
        Task<bool> VerifyAsync(string senha, string hashArmazenado, string saltArmazenado);
    }
}
