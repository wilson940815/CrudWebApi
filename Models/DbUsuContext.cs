using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Models;

public partial class DbUsuContext : DbContext
{
    public DbUsuContext()
    {
    }

    public DbUsuContext(DbContextOptions<DbUsuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuary> Usuaries { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuary__3213E83F798CFEDD");

            entity.ToTable("usuary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreate)
                .HasColumnType("datetime")
                .HasColumnName("fecha_create");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
