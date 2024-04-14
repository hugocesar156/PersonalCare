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
        public virtual DbSet<USUARIO> USUARIOs { get; set; } = null!;
        public virtual DbSet<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=db_personalcare_acesso;persist security info=True;user id=HUGO-PC\\hugoc;TrustServerCertificate=True;MultipleActiveResultSets=True;Trusted_Connection=True;");
            }
        }

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

                entity.HasOne(d => d.ID_ACAONavigation)
                    .WithMany(p => p.USUARIO_PERMISSAOs)
                    .HasForeignKey(d => d.ID_ACAO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_P__ID_AC__4222D4EF");

                entity.HasOne(d => d.ID_ENTIDADENavigation)
                    .WithMany(p => p.USUARIO_PERMISSAOs)
                    .HasForeignKey(d => d.ID_ENTIDADE)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_P__ID_EN__412EB0B6");

                entity.HasOne(d => d.ID_USUARIONavigation)
                    .WithMany(p => p.USUARIO_PERMISSAOs)
                    .HasForeignKey(d => d.ID_USUARIO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO_P__ID_AC__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
