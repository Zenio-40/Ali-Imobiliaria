using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace C02.Aplication.Servico
{
    public class SmsService(HttpClient httpClient, ILogger<SmsService> logger, IConfiguration configuration) : ISmsService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<SmsService> _logger = logger;
        private readonly IConfiguration _configuration = configuration;

        public async Task<bool> SendSmsAsync(string telefone, string mensagemTexto, string nif)
        {
            try
            {
                // Validar parâmetros
                if (string.IsNullOrWhiteSpace(telefone))
                {
                    _logger.LogError("Número de telefone inválido para envio de SMS");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(mensagemTexto))
                {
                    _logger.LogError("Mensagem de SMS vazia");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(nif))
                {
                    _logger.LogError("NIF não configurado para envio de SMS");
                    return false;
                }

                // Verificar se estamos em desenvolvimento ou se simulação está habilitada
                var environment = _configuration["ASPNETCORE_ENVIRONMENT"] ?? "Production";
                var simularEnvio = _configuration.GetValue<bool>("Sms:SimularEnvio", false);

                if (environment == "Development" || simularEnvio)
                {
                    _logger.LogInformation($"[SIMULAÇÃO] SMS enviado para {telefone}: {mensagemTexto}");
                    _logger.LogInformation($"[SIMULAÇÃO] NIF usado: {nif}");
                    await Task.Delay(500); // Simular latência
                    return true;
                }

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

                _logger.LogInformation($"Tentando enviar SMS para {telefone} com NIF {nif}");

                var response = await _httpClient.PostAsJsonAsync("/enviar/sms", request);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"SMS enviado com sucesso para {telefone}");
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Falha ao enviar SMS. Status: {response.StatusCode}, Conteúdo: {errorContent}");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, $"Erro de HTTP ao enviar SMS para {telefone}: {httpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro inesperado ao enviar SMS para {telefone}: {ex.Message}");
                return false;
            }
        }
    }
}