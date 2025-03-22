using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using PersonalCare.DAL.Models.Base;
using PersonalCare.Shared;

namespace PersonalCare.DAL.Context
{
    public partial class DataContextBase : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContextBase(DbContextOptions<DataContextBase> options, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<CATEGORIA_TREINO> CATEGORIA_TREINOs { get; set; } = null!;
        public virtual DbSet<CONTATO_CONTum> CONTATO_CONTAs { get; set; } = null!;
        public virtual DbSet<CONTum> CONTAs { get; set; } = null!;
        public virtual DbSet<FICHA> FICHAs { get; set; } = null!;
        public virtual DbSet<HORARIO_CONTA_TREINO> HORARIO_CONTA_TREINOs { get; set; } = null!;
        public virtual DbSet<ITEM_FICHA> ITEM_FICHAs { get; set; } = null!;
        public virtual DbSet<TREINO> TREINOs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var idEmpresa = _httpContextAccessor.HttpContext.User.FindFirst(PersonalCareClaims.ID_EMPRESA)?.Value;
            var connectionString = string.Format(_configuration.GetConnectionString("PersonalCareBase"), idEmpresa);

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA_TREINO>(entity =>
            {
                entity.ToTable("CATEGORIA_TREINO");

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CONTATO_CONTum>(entity =>
            {
                entity.ToTable("CONTATO_CONTA");

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

                entity.HasOne(d => d.ID_CONTANavigation)
                    .WithMany(p => p.CONTATO_CONTa)
                    .HasForeignKey(d => d.ID_CONTA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CONTATO_C__ID_CO__4D94879B");
            });

            modelBuilder.Entity<CONTum>(entity =>
            {
                entity.ToTable("CONTA");

                entity.HasIndex(e => e.EMAIL, "UQ__CONTA__161CF724624DB52F")
                    .IsUnique();

                entity.HasIndex(e => e.CPF, "UQ__CONTA__C1F897316A70CF4E")
                    .IsUnique();

                entity.Property(e => e.ALTURA).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BIOTIPO)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CPF)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DATA_ATUALIZACAO).HasColumnType("datetime");

                entity.Property(e => e.DATA_CADASTRO).HasColumnType("datetime");

                entity.Property(e => e.DATA_NASCIMENTO).HasColumnType("date");

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

            modelBuilder.Entity<FICHA>(entity =>
            {
                entity.ToTable("FICHA");

                entity.Property(e => e.DATA_CRIACAO).HasColumnType("date");

                entity.Property(e => e.DATA_VALIDADE).HasColumnType("date");

                entity.HasOne(d => d.ID_CONTANavigation)
                    .WithMany(p => p.FICHAs)
                    .HasForeignKey(d => d.ID_CONTA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FICHA__ID_CONTA__5070F446");
            });

            modelBuilder.Entity<HORARIO_CONTA_TREINO>(entity =>
            {
                entity.ToTable("HORARIO_CONTA_TREINO");

                entity.HasOne(d => d.ID_CONTANavigation)
                    .WithMany(p => p.HORARIO_CONTA_TREINOs)
                    .HasForeignKey(d => d.ID_CONTA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HORARIO_C__ID_CO__5CD6CB2B");
            });

            modelBuilder.Entity<ITEM_FICHA>(entity =>
            {
                entity.ToTable("ITEM_FICHA");

                entity.Property(e => e.GRUPO)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_FICHANavigation)
                    .WithMany(p => p.ITEM_FICHAs)
                    .HasForeignKey(d => d.ID_FICHA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITEM_FICH__ID_FI__5812160E");

                entity.HasOne(d => d.ID_TREINONavigation)
                    .WithMany(p => p.ITEM_FICHAs)
                    .HasForeignKey(d => d.ID_TREINO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ITEM_FICH__ID_TR__59063A47");
            });

            modelBuilder.Entity<TREINO>(entity =>
            {
                entity.ToTable("TREINO");

                entity.Property(e => e.DESCRICAO)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NOME)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ID_CATEGORIA_TREINONavigation)
                    .WithMany(p => p.TREINOs)
                    .HasForeignKey(d => d.ID_CATEGORIA_TREINO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TREINO__ID_CATEG__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
