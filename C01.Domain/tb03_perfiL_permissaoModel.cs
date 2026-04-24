using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("perfilPermissao")]
public class tb03_perfiL_permissaoModel
{
    [Column("id")]
    public int id {get; set;}

    [Column("Idtb02_perfilModel")]
    public int Idtb02_perfilModel {get; set;}

    [Column("Idtb01_permissaoModel")]
    public int Idtb01_permissaoModel {get; set;}

    [Column("Estado")]
    public bool Estado {get; set;}

    public tb01_permissaoModel Permissao {get; set;} = null!;

    public tb02_perfilModel Perfil {get; set;} = null!;
    

}

