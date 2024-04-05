using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data;

public partial class SocialMediaContext : DbContext
{
    public SocialMediaContext()
    {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
    {
    }

    public  DbSet<Comment> Comments { get; set; }

    public  DbSet<Post> Posts { get; set; }

    public  DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comentatio");

            entity.HasKey(e => e.CommentId);

            entity.Property(e => e.CommentId)
            .HasColumnName("IdComment")
            .ValueGeneratedNever();

            entity.Property(e => e.PostId)
            .HasColumnName("IdPublicacion");


            entity.Property(e => e.UserId)
            .HasColumnName("IdUsuario");

            entity.Property(e => e.IsActive)
           .HasColumnName("Activo");

                

            entity.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Date)    
            .HasColumnName("Fecha")
            .HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Publicacion");

            entity.HasKey(e => e.PostId);

            entity.Property(e => e.PostId)
            .HasColumnName("IdPublicacion");

            entity.Property(e => e.UserId)
            .HasColumnName("IdUsuario");



            entity.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.Date)
            .HasColumnName("Fecha")
            .HasColumnType("datetime");

            entity.Property(e => e.Image)
                .HasColumnName("Imagen")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Usuario");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId)
            .HasColumnName("IdUsuario");

            entity.Property(e => e.LastName)
                .HasColumnName("Apellidos")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.DateOfBirth)
            .HasColumnName("FechaNacimiento")
            .HasColumnType("date");

            entity.Property(e => e.FirtName)
                .HasColumnName("Nombres")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Telephone)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.IsActive)
                .HasColumnName("Activo");

        });

    }

}
