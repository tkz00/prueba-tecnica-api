using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_tecnica_api.models;

public partial class PruebaTecnicaDbContext : DbContext
{
    public PruebaTecnicaDbContext()
    {
    }

    public PruebaTecnicaDbContext(DbContextOptions<PruebaTecnicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Contractitem> Contractitems { get; set; }

    public virtual DbSet<Item> Items { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySql("server=localhost;database=prueba_tecnica_db;user=theo;pwd=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contracts");

            entity.Property(e => e.ColegioCurso).HasMaxLength(50);
            entity.Property(e => e.ColegioLocalidad).HasMaxLength(50);
            entity.Property(e => e.ColegioNivel).HasMaxLength(50);
            entity.Property(e => e.ColegioNombre).HasMaxLength(50);
            entity.Property(e => e.Comision).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasMaxLength(6);
            entity.Property(e => e.FechaAlta).HasMaxLength(6);
            entity.Property(e => e.FechaEntrega).HasMaxLength(6);
            entity.Property(e => e.Total).HasPrecision(10, 2);
            entity.Property(e => e.UpdateDate).HasMaxLength(6);
        });

        modelBuilder.Entity<Contractitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contractitems");

            entity.HasIndex(e => e.ContractId, "FK_ContractItems_Contracts_ContractId");

            entity.HasIndex(e => e.ItemId, "IX_ContractItems_ItemId");

            entity.Property(e => e.CreateDate).HasMaxLength(6);
            entity.Property(e => e.UpdateDate).HasMaxLength(6);

            entity.HasOne(d => d.Contract).WithMany(p => p.Contractitems)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_ContractItems_Contracts_ContractId");

            entity.HasOne(d => d.Item).WithMany(p => p.Contractitems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ContractItems_Items_ItemId");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.HasIndex(e => e.Nombre, "IX_Items_Nombre").IsUnique();

            entity.Property(e => e.CreateDate).HasMaxLength(6);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
            entity.Property(e => e.UpdateDate).HasMaxLength(6);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
