using Corretora.C01.Domain;
using Microsoft.EntityFrameworkCore;

namespace Corretora.C03.Infra.Data;

public class CorretoraDbContext(DbContextOptions<CorretoraDbContext> options) : DbContext(options)
{
    public DbSet<tb01_permissaoModel> Tabela01Permissao {get; set;}

    public DbSet<tb02_perfilModel> Tabela02Perfil {get; set;}

    public DbSet<tb03_perfiL_permissaoModel> Tabela03PerfilPermissao {get; set;}

    public DbSet<tb04_funcionarioModel> Tabela04Funcinario {get; set;}

    public DbSet<tb05_credencial_acessoModel> Tabela05Credencial {get; set;}

    public DbSet<tb06_clienteModel> Tabela06Cliente {get; set;}

    public DbSet<tb07_telefoneModel> Tabela07Telefone {get; set;}

    public DbSet<tb08_emailModel> Tabela08Email {get; set;}

    public DbSet<tb09_tipo_imovelModel> Tabela09TipolaImovel {get; set;}

    public DbSet<tb10_tipologiaModel> Tabela10Tipologia {get; set;}

    public DbSet<tb11_imovelModel> Tabela11Imovel {get; set;}

    public DbSet<tb12_fotoModel> Tabela12Foto {get; set;}

    public DbSet<tb13_videoModel> Tabela13Video {get; set;}

    public DbSet<tb14_provinciaModel> Tabela14Pronvincia {get; set;}

    public DbSet<tb15_municipioModel> Tabela15Municipio {get; set;}

    public DbSet<tb16_bairroModel> Tabela16Bairro {get; set;}

    public DbSet<tb17_enderecoModel> Tabela17Enderco {get; set;}
    
    public DbSet<tb18_proprietarioModel> Tabela18Proprietario {get; set;}

    public DbSet<tb19_estado_solicitacaoModel> Tabela19EstadoSolicitacao {get; set;}

    public DbSet<tb20_solicitacaoModel> Tabela20Solicitacao {get; set;}

    public DbSet<tb21_favoritoModel> Tabela21Favorito {get; set;}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<tb03_perfiL_permissaoModel>(entity =>
        {
            entity.HasKey(perfilP => perfilP.Perfil).WithOne(perfil => perfil.Permissao);
        });

        
    }


}
