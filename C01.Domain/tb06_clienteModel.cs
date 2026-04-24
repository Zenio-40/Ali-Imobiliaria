using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Cliente")]
public class tb06_clienteModel
{
    [Column("Id")]
    public int Id {get; set;}

    [Column("Idtb02_perfilModel")]
    public int Idtb02_perfilModel {get; set;}

    [Column("Nome")]
    public string Nome {get; set;} = string.Empty;

    [Column("Estado")]
    public bool Estado {get; set;}

    public ICollection<tb02_perfilModel> Perfis {get; set;} = [];

    public ICollection<tb07_telefoneModel> Telefone {get; set;} = [];

    public ICollection<tb08_emailModel> Email {get; set;} = [];

    public ICollection<tb21_favoritoModel> Favoritos {get; set;} = [];

    public ICollection<tb20_solicitacaoModel> Solicitacoes {get; set;} = [];
}


