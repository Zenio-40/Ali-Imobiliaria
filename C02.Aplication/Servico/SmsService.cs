using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace C02.Aplication.Servico
{
    public class SmsService(HttpClient httpClient) : ISmsService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<bool> SendSmsAsync(string telefone, string mensagemTexto, string nif)
        {
            var request = new
            {
                mensagem = new[]
                {
                    new
                    {
                        telefone = telefone,
                        mensagemTexto = mensagemTexto
                    }
                },
                nif = nif
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://sms.gsaplatform.co/enviar/sms", request);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}