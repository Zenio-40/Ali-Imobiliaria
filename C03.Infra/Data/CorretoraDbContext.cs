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
            entity.HasOne(e => e.Permissao)
                .WithMany(p => p.PerfilPermissao)
                .HasForeignKey(e => e.Idtb01_permissaoModel);

            entity.HasOne(e => e.Perfil)
                .WithMany(p => p.PerfilPermissao)
                .HasForeignKey(e => e.Idtb02_perfilModel);
        });

        modelBuilder.Entity<tb04_funcionarioModel>(entity =>
        {
            entity.HasOne(e => e.Perfil)
                .WithMany()
                .HasForeignKey(e => e.Idtb02_perfilModel);
        });

        modelBuilder.Entity<tb05_credencial_acessoModel>(entity =>
        {
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Credencial)
                .HasForeignKey(e => e.Idtb04_funcionarioModel);
        });

        modelBuilder.Entity<tb07_telefoneModel>(entity =>
        {
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Telefone)
                .HasForeignKey(e => e.tb04_funcionarioModel);

            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Telefone)
                .HasForeignKey(e => e.tb06_clienteModel);
        });

        modelBuilder.Entity<tb08_emailModel>(entity =>
        {
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Email)
                .HasForeignKey(e => e.tb04_funcionarioModel);

            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Email)
                .HasForeignKey(e => e.tb06_clienteModel);
        });

        modelBuilder.Entity<tb11_imovelModel>(entity =>
        {
            entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Imovel)
                .HasForeignKey(e => e.tb04_funcionarioModel);

            entity.HasOne(e => e.TipoImovel)
                .WithMany(t => t.Imovel)
                .HasForeignKey(e => e.tb09_tipo_imovelModel);

            entity.HasOne(e => e.Tipologia)
                .WithMany(t => t.Imovel)
                .HasForeignKey(e => e.tb10_tipologiaModel);

            entity.HasOne(e => e.ProprietarioModel)
                .WithMany(p => p.Imoveis)
                .HasForeignKey(e => e.tb18_proprietarioModel);
        });

        modelBuilder.Entity<tb12_fotoModel>(entity =>
        {
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Foto)
                .HasForeignKey(e => e.tb11_imovelModel);
        });

        modelBuilder.Entity<tb13_videoModel>(entity =>
        {
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Video)
                .HasForeignKey(e => e.tb11_imovelModel);
        });

        modelBuilder.Entity<tb17_enderecoModel>(entity =>
        {
            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Endereco)
                .HasForeignKey(e => e.tb11_imovelModel);

            entity.HasOne(e => e.Bairro)
                .WithMany(b => b.Endereco)
                .HasForeignKey(e => e.tb16_bairroModel);
        });

        modelBuilder.Entity<tb15_municipioModel>(entity =>
        {
            entity.HasOne(e => e.Provincia)
                .WithMany(p => p.Municipio)
                .HasForeignKey(e => e.tb14_provinciaModel);
        });

        modelBuilder.Entity<tb16_bairroModel>(entity =>
        {
            entity.HasOne(e => e.Municipio)
                .WithMany(m => m.Bairro)
                .HasForeignKey(e => e.tb15_municipioModel);
        });

        modelBuilder.Entity<tb20_solicitacaoModel>(entity =>
        {
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Solicitacoes)
                .HasForeignKey(e => e.tb06_clienteModel);

            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Solicitacao)
                .HasForeignKey(e => e.tb11_imovelModel);

            entity.HasOne(e => e.EstadoSolicitacao)
                .WithMany(s => s.Solicitacao)
                .HasForeignKey(e => e.tb19_estado_solicitacaoModel);
        });

        modelBuilder.Entity<tb21_favoritoModel>(entity =>
        {
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Favoritos)
                .HasForeignKey(e => e.tb06_clienteModel);

            entity.HasOne(e => e.Imovel)
                .WithMany(i => i.Favorito)
                .HasForeignKey(e => e.tb11_imovelModel);
        });
    }

}