using System;
using System.ComponentModel.DataAnnotations;

namespace Corretora.C02.Aplication.CasosUso.SolicitacaoUseCase.DTOs;

public class CadastrarSolicitacaoDTO
{
    [Required(ErrorMessage = "Informe o ID do cliente.")]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Informe o ID do imóvel.")]
    public int IdImovel { get; set; }

    [Required(ErrorMessage = "Informe o ID do estado da solicitação.")]
    public int IdEstadoSolicitacao { get; set; }
}

