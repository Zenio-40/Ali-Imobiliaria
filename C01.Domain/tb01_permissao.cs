using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Permissao")]
public class tb01_permissaoModel
{
    [Column("id")]
    public int id {get; set;}

    [Column("descricao")]
    public string Descricao {get; set;} = string.Empty;
}
