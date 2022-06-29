using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace V2.Models
{
    public partial class v2Context : DbContext
    {
        public v2Context()
        {
        }

        public v2Context(DbContextOptions<v2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Rentar> Rentars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__A3C02A105F76C9B2");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__D59466425D2CF7E1");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__MARCA__4076A887FB34631A");

                entity.ToTable("MARCA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__MODELO__CC30D30CD3559AB2");

                entity.ToTable("MODELO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rentar>(entity =>
            {
                entity.HasKey(e => e.IdRentar)
                    .HasName("PK__RENTAR__F25CCA30C11A53ED");

                entity.ToTable("RENTAR");

                entity.Property(e => e.FechaRentado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaRetorno).HasColumnType("datetime");

                entity.HasOne(d => d.oCategoria)
                    .WithMany(p => p.Rentars)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Categoria");

                entity.HasOne(d => d.oCliente)
                    .WithMany(p => p.Rentars)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Cliente");

                entity.HasOne(d => d.oMarca)
                    .WithMany(p => p.Rentars)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Marca");

                entity.HasOne(d => d.oModelo)
                    .WithMany(p => p.Rentars)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK_Modelo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
