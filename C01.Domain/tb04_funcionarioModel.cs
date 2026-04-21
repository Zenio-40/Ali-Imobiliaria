using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("funcionario")]
public class tb04_funcionarioModel
{
    [Column("Id")]
    public int Id {get; set;}

    [Column("Idtb02_perfilModel")]
    public int Idtb02_perfilModel {get; set;}

    [Column("Nome")]
    public string Nome {get; set;} = string.Empty;

    [Column("Estado")]
    public bool Estado {get; set;}
}

