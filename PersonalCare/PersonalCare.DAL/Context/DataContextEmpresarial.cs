using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonalCare.DAL.Models.Empresarial;

namespace PersonalCare.DAL.Context
{
    public partial class DataContextEmpresarial : DbContext
    {
        public DataContextEmpresarial()
        {
        }

        public DataContextEmpresarial(DbContextOptions<DataContextEmpresarial> options)
            : base(options)
        {
        }

        public virtual DbSet<EMPRESA> EMPRESAs { get; set; } = null!;
        public virtual DbSet<EMPRESA_CONTATO> EMPRESA_CONTATOs { get; set; } = null!;
        public virtual DbSet<EMPRESA_MIDIASOCIAL> EMPRESA_MIDIASOCIALs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=db_personalcare_empresarial;persist security info=True;user id=HUGO-PC\\hugoc;TrustServerCertificate=True;MultipleActiveResultSets=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EMPRESA>(entity =>
            {
                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.GUID, "UQ__EMPRESA__15B69B8FC15D65FC")
                    .IsUnique();

                entity.Property(e => e.BAIRRO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CEP)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CIDADE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CNPJ)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.GUID)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.LOGRADOURO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NOME_FANTASIA)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NUMERO)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RAZAO_SOCIAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UF)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EMPRESA_CONTATO>(entity =>
            {
                entity.ToTable("EMPRESA_CONTATO");

                entity.Property(e => e.DDD)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DDI)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NUMERO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_EMPRESANavigation)
                    .WithMany(p => p.EMPRESA_CONTATOs)
                    .HasForeignKey(d => d.ID_EMPRESA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPRESA_C__ID_EM__5FB337D6");
            });

            modelBuilder.Entity<EMPRESA_MIDIASOCIAL>(entity =>
            {
                entity.ToTable("EMPRESA_MIDIASOCIAL");

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.URL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_EMPRESANavigation)
                    .WithMany(p => p.EMPRESA_MIDIASOCIALs)
                    .HasForeignKey(d => d.ID_EMPRESA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPRESA_M__ID_EM__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
