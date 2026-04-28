using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public interface IPasswordHash
    {
        Task<(string Hash, string Salt)> HashAsync(string senha);
    }
}
