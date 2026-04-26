using System;
using System.ComponentModel.DataAnnotations;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

public class PesquisarPorTextoFuncionarioDTO
{
    [Required(ErrorMessage = "Informe o texto para pesquisa.")]
    public string Texto { get; set; } = String.Empty;
}