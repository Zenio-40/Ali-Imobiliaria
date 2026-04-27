using System;
using System.ComponentModel.DataAnnotations;

namespace Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;

public class ActualizarImovelDTO
{
    [Required(ErrorMessage = "Informe o ID do imóvel.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a descrição do imóvel.")]
    public string Descricao { get; set; } = String.Empty;

    [Required(ErrorMessage = "Informe o preço do imóvel.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Selecione o tipo de imóvel.")]
    public int IdTipoImovel { get; set; }

    [Required(ErrorMessage = "Selecione a tipologia.")]
    public int IdTipologia { get; set; }

    [Required(ErrorMessage = "Selecione o funcionário responsável.")]
    public int IdFuncionario { get; set; }

    [Required(ErrorMessage = "Selecione o proprietário.")]
    public int IdProprietario { get; set; }

    public bool Estado { get; set; } = true;
}

