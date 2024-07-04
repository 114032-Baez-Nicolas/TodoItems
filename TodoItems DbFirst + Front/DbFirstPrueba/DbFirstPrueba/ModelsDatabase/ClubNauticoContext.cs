using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstPrueba.ModelsDatabase;

public partial class ClubNauticoContext : DbContext
{
    public ClubNauticoContext()
    {
    }

    public ClubNauticoContext(DbContextOptions<ClubNauticoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ITSPIXELES12;Initial Catalog=club_nautico;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasIndex(e => e.CategoriaId, "IX_TodoItems_CategoriaId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreTarea).HasMaxLength(100);

            entity.HasOne(d => d.Categoria).WithMany(p => p.TodoItems).HasForeignKey(d => d.CategoriaId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
