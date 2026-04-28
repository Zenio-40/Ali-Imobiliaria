using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string telefone, string mensagemTexto, string nif);
    }
}

