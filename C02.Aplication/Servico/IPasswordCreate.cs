using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public interface IPasswordCreate
    {
        Task<string> GenerateAsync();
    }
}
