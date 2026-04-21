using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corretora.C01.Domain;
[Table("Video")]
public class tb13_videoModel
{
    [Column("Id")]
    public int Id {get; set;}

    [Column("TipoImovel")]
    public int tb09_tipo_imovel {get; set;}

    [Column("Video")]
    public string Video {get; set;} = string.Empty;
}
