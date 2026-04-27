using System;
using System.ComponentModel.DataAnnotations;

namespace Corretora.C02.Aplication.CasosUso.ClienteUseCase.DTOs;

public class CadastrarClienteDTO
{
    [Required(ErrorMessage = "Informe o nome do cliente.")]
    public string ClienteNome { get; set; } = String.Empty;

    [Required(ErrorMessage = "Informe o numero de telefone do cliente.")]
    [MaxLength(9)]
    public string ClienteTelefone { get; set; } = String.Empty;

    [Required(ErrorMessage = "Informe o email do cliente.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string ClienteEmail { get; set; } = String.Empty;

    [Required(ErrorMessage = "Selecione o perfil do cliente.")]
    public int ClienteIdPerfil { get; set; }
}

