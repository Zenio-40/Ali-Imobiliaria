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

        // tb01_permissaoModel
        modelBuilder.Entity<tb01_permissaoModel>(entity =>
        {
            entity.HasKey(e => e.id);
        });

        // tb02_perfilModel
        modelBuilder.Entity<tb02_perfilModel>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey("Idtb02_perfilModel") // assuming FK in cliente
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb03_perfiL_permissaoModel
        modelBuilder.Entity<tb03_perfiL_permissaoModel>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.HasOne(e => e.Perfil)
                .WithMany(p => p.PerfilPermissao)
                .HasForeignKey(e => e.Idtb02_perfilModel)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Permissao)
                .WithMany(p => p.PerfilPermissao)
                .HasForeignKey(e => e.Idtb01_permissaoModel)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // tb04_funcionarioModel
        modelBuilder.Entity<tb04_funcionarioModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Perfil)
                .WithMany()
                .HasForeignKey(e => e.Idtb02_perfilModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb05_credencial_acessoModel
        modelBuilder.Entity<tb05_credencial_acessoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Credencial)
                .HasForeignKey(e => e.Idtb04_funcionarioModel)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // tb06_clienteModel
        modelBuilder.Entity<tb06_clienteModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne<tb02_perfilModel>()
                .WithMany()
                .HasForeignKey(e => e.Idtb02_perfilModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb07_telefoneModel
        modelBuilder.Entity<tb07_telefoneModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Telefone)
                .HasForeignKey(e => e.tb04_funcionarioModel)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Telefone)
                .HasForeignKey(e => e.tb06_clienteModel)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // tb08_emailModel
        modelBuilder.Entity<tb08_emailModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Email)
                .HasForeignKey(e => e.tb04_funcionarioModel)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Email)
                .HasForeignKey(e => e.tb06_clienteModel)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // tb09_tipo_imovelModel
        modelBuilder.Entity<tb09_tipo_imovelModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // tb10_tipologiaModel
        modelBuilder.Entity<tb10_tipologiaModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // tb11_imovelModel
        modelBuilder.Entity<tb11_imovelModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Imovel)
                .HasForeignKey(e => e.tb04_funcionarioModel)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.TipoImovel)
                .WithMany(t => t.Imovel)
                .HasForeignKey(e => e.tb09_tipo_imovelModel)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Tipologia)
                .WithMany()
                .HasForeignKey(e => e.tb10_tipologiaModel)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.ProprietarioModel)
                .WithMany(p => p.Imoveis)
                .HasForeignKey(e => e.tb18_proprietarioModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

         // tb12_fotoModel
        modelBuilder.Entity<tb12_fotoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Foto)
                .HasForeignKey("tb11_imovelModel") // assuming FK added
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<tb09_tipo_imovelModel>()
                .WithMany()
                .HasForeignKey(e => e.tb09_tipo_imovel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb13_videoModel
        modelBuilder.Entity<tb13_videoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Video)
                .HasForeignKey("tb11_imovelModel") // assuming FK
                .OnDelete(DeleteBehavior.Cascade);
        });

        // tb14_provinciaModel
        modelBuilder.Entity<tb14_provinciaModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // tb15_municipioModel
        modelBuilder.Entity<tb15_municipioModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Provincia)
                .WithMany(p => p.Municipio)
                .HasForeignKey(e => e.tb14_provinciaModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb16_bairroModel
        modelBuilder.Entity<tb16_bairroModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Municipio)
                .WithMany(m => m.Bairro)
                .HasForeignKey(e => e.tb15_municipioModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb17_enderecoModel
        modelBuilder.Entity<tb17_enderecoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Bairro)
                .WithMany(b => b.Endereco)
                .HasForeignKey(e => e.tb16_bairroModel)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Endereco)
                .HasForeignKey(e => e.tb11_imovelModel)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // tb18_proprietarioModel
        modelBuilder.Entity<tb18_proprietarioModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // tb19_estado_solicitacaoModel
        modelBuilder.Entity<tb19_estado_solicitacaoModel>(entity =>
        {
            entity.HasKey(e => e.Id );
        });

        // tb20_solicitacaoModel
        modelBuilder.Entity<tb20_solicitacaoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Solicitacoes)
                .HasForeignKey(e => e.tb06_clienteModel)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Solicitacao)
                .HasForeignKey(e => e.tb11_imovelModel)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.EstadoSolicitacao)
                .WithMany()
                .HasForeignKey(e => e.tb19_estado_solicitacaoModel)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // tb21_favoritoModel
        modelBuilder.Entity<tb21_favoritoModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Favoritos)
                .HasForeignKey(e => e.tb06_clienteModel)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Favorito)
                .HasForeignKey(e => e.tb11_imovelModel)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }


}
