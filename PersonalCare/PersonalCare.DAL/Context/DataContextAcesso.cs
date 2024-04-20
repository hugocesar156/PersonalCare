using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonalCare.DAL.Models.Acesso;

namespace PersonalCare.DAL.Context
{
    public partial class DataContextAcesso : DbContext
    {
        public DataContextAcesso()
        {
        }

        public DataContextAcesso(DbContextOptions<DataContextAcesso> options)
            : base(options)
        {
        }

        public virtual DbSet<ACAO> ACAOs { get; set; } = null!;
        public virtual DbSet<ENTIDADE> ENTIDADEs { get; set; } = null!;
        public virtual DbSet<PERMISSAO> PERMISSAOs { get; set; } = null!;
        public virtual DbSet<USUARIO> USUARIOs { get; set; } = null!;
        public virtual DbSet<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; } = null!;
        public virtual DbSet<USUARIO_REDEFINICAO_SENHA> USUARIO_REDEFINICAO_SENHAs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACAO>(entity =>
            {
                entity.ToTable("ACAO");

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ENTIDADE>(entity =>
            {
                entity.ToTable("ENTIDADE");

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PERMISSAO>(entity =>
            {
                entity.ToTable("PERMISSAO");

                entity.Property(e => e.DESCRICAO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NOME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_ACAONavigation)
                    .WithMany(p => p.PERMISSAOs)
                    .HasForeignKey(d => d.ID_ACAO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERMISSAO__ID_AC__59FA5E80");

                entity.HasOne(d => d.ID_ENTIDADENavigation)
                    .WithMany(p => p.PERMISSAOs)
                    .HasForeignKey(d => d.ID_ENTIDADE)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERMISSAO__ID_EN__59063A47");
            });

            modelBuilder.Entity<USUARIO>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.EMAIL, "UQ__USUARIO__161CF7244F496BAF")
                    .IsUnique();

                entity.Property(e => e.DATA_ATUALIZACAO).HasColumnType("datetime");

                entity.Property(e => e.DATA_CADASTRO).HasColumnType("datetime");

                entity.Property(e => e.DATA_ULTIMO_ACESSO).HasColumnType("datetime");

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ID_EMPRESA)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NOME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SALT)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.SENHA)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USUARIO_PERMISSAO>(entity =>
            {
                entity.ToTable("USUARIO_PERMISSAO");

                entity.HasOne(d => d.ID_PERMISSAONavigation)
                    .WithMany(p => p.USUARIO_PERMISSAOs)
                    .HasForeignKey(d => d.ID_PERMISSAO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_P__ID_PE__628FA481");

                entity.HasOne(d => d.ID_USUARIONavigation)
                    .WithMany(p => p.USUARIO_PERMISSAOs)
                    .HasForeignKey(d => d.ID_USUARIO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_P__ID_US__619B8048");
            });

            modelBuilder.Entity<USUARIO_REDEFINICAO_SENHA>(entity =>
            {
                entity.ToTable("USUARIO_REDEFINICAO_SENHA");

                entity.Property(e => e.CODIGO)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DATA_PEDIDO).HasColumnType("datetime");

                entity.HasOne(d => d.ID_USUARIONavigation)
                    .WithMany(p => p.USUARIO_REDEFINICAO_SENHAs)
                    .HasForeignKey(d => d.ID_USUARIO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_R__ID_US__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
