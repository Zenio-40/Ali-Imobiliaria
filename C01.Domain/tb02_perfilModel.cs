using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Perfil")]
public class tb02_perfilModel
{
    [Column("id")]
    public int id {get; set;}

    [Column("descricao")]
    public string Descricao  {get; set;} = string.Empty;

    public tb06_clienteModel Cliente {get; set;} = null!;

    public ICollection<tb03_perfiL_permissaoModel> PerfilPermissao {get; set;} = [];
}
