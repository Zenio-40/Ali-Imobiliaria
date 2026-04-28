using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace C02.Aplication.Servico
{
    public class SmsService : ISmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SmsService> _logger;

        public SmsService(HttpClient httpClient, IConfiguration configuration, ILogger<SmsService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendSmsAsync(string telefone, string mensagemTexto, string nif)
        {
            var simular = _configuration.GetValue<bool>("Sms:SimularEnvio");

            if (simular)
            {
                _logger.LogInformation("[SIMULAÇÃO] SMS para {Telefone}: {Mensagem}", telefone, mensagemTexto);
                return true;
            }

            var request = new
            {
                mensagem = new[]
                {
                    new
                    {
                        telefone,
                        mensagemTexto
                    }
                },
                nif
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/enviar/sms", request);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("SMS enviado com sucesso para {Telefone}", telefone);
                    return true;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Falha ao enviar SMS para {Telefone}. Status: {StatusCode}. Resposta: {Resposta}",
                    telefone, (int)response.StatusCode, errorContent);
                return false;
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogError(ex, "Timeout ao enviar SMS para {Telefone}", telefone);
                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erro de rede ao enviar SMS para {Telefone}", telefone);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao enviar SMS para {Telefone}", telefone);
                return false;
            }
        }
    }
}

