using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Imovel")]
public class tb11_imovelModel
{
    [Column("Id")]
    public int Id {get; set;}

    [Column("tb04_funcionarioModel")]
    public int tb04_funcionarioModel {get; set;}

    [Column("tb09_tipo_imovelModel")]
    public int tb09_tipo_imovelModel {get; set;}

    [Column("tb010_tipologiaModel")]
    public int tb10_tipologiaModel {get; set;}

    [Column("DEcricao")]
    public string Descricao {get; set;} = string.Empty;

    [Column("Preco")]
    public string Preco {get; set;} = string.Empty;

    [Column("Estado")]
    public bool Estado {get; set;}
}
