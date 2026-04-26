using System;
using System.ComponentModel.DataAnnotations;

namespace Corretora.C02.Aplication.CasosUso.FuncionarioUseCase.DTOs;

public class RemoverFuncionarioDTO
{
    [Required(ErrorMessage = "Informe o ID do funcionário.")]
    public int Id { get; set; }
}