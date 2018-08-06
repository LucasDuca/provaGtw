using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace duca_gateway.Models
{
    public partial class duca_gtwContext : DbContext
    {
        public duca_gtwContext()
        {
        }

        public duca_gtwContext(DbContextOptions<duca_gtwContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configuracao> Configuracao { get; set; }
        public virtual DbSet<Lojista> Lojista { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=duca_gtw;user=root;pwd=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracao);

                entity.ToTable("configuracao");

                entity.HasIndex(e => e.IdLojista)
                    .HasName("FK_LOJISTA_idx");

                entity.Property(e => e.IdConfiguracao)
                    .HasColumnName("id_configuracao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Antifraude)
                    .IsRequired()
                    .HasColumnName("antifraude")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Cielo)
                    .IsRequired()
                    .HasColumnName("cielo")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Cielokey)
                    .HasColumnName("cielokey")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IdLojista)
                    .HasColumnName("id_lojista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RuleMaster)
                    .HasColumnName("rule_master")
                    .HasColumnType("char(1)");

                entity.Property(e => e.RuleVisa)
                    .HasColumnName("rule_visa")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Stone)
                    .IsRequired()
                    .HasColumnName("stone")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Stonekey)
                    .HasColumnName("stonekey")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdLojistaNavigation)
                    .WithMany(p => p.Configuracao)
                    .HasForeignKey(d => d.IdLojista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOJISTA");
            });

            modelBuilder.Entity<Lojista>(entity =>
            {
                entity.HasKey(e => e.IdLojista);

                entity.ToTable("lojista");

                entity.Property(e => e.IdLojista)
                    .HasColumnName("id_lojista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Razaosocial)
                    .IsRequired()
                    .HasColumnName("razaosocial")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.IdTransacao);

                entity.ToTable("transacao");

                entity.HasIndex(e => e.IdLojista)
                    .HasName("fk_id_loja_idx");

                entity.Property(e => e.IdTransacao)
                    .HasColumnName("id_transacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cielo)
                    .HasColumnName("cielo")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CreditCard)
                    .IsRequired()
                    .HasColumnName("credit_card")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.IdLojista)
                    .HasColumnName("id_lojista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Master)
                    .HasColumnName("master")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Stone)
                    .HasColumnName("stone")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Visa)
                    .HasColumnName("visa")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdLojistaNavigation)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.IdLojista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_loja");
            });
        }
    }
}
