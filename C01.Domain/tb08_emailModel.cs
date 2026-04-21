using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Email")]
public class tb08_emailModel
{
    [Column("Id")]
    public int Id {get; set;}

    [Column("tb06_clienteModel")]
    public int tb06_clienteModel {get; set;}

    [Column("tb04_funcionarioMOdel")]
    public int tb04_funcionarioModel {get; set;}

    [Column("Email")]
    public string email {get; set;} = string.Empty;

}
