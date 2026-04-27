using System;

namespace Corretora.C02.Aplication.CasosUso.ImovelUseCase.DTOs;

public class ImovelDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; } = String.Empty;
    public decimal Preco { get; set; }
    public bool Estado { get; set; }
    public int IdTipoImovel { get; set; }
    public string TipoImovel { get; set; } = String.Empty;
    public int IdTipologia { get; set; }
    public string Tipologia { get; set; } = String.Empty;
    public int IdFuncionario { get; set; }
    public string Funcionario { get; set; } = String.Empty;
    public int IdProprietario { get; set; }
    public string Proprietario { get; set; } = String.Empty;
}

