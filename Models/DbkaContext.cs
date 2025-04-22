using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Store.Models;

public partial class DbkaContext : DbContext
{
    public DbkaContext()
    {
    }

    public DbkaContext(DbContextOptions<DbkaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK_Producto"); // Nombre más simple

            entity.ToTable("Producto");

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.Property(e => e.Name)
                .HasMaxLength(200);

            entity.Property(e => e.Price)
                .HasColumnType("numeric(10,2)"); // Tipo específico para PostgreSQL
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
