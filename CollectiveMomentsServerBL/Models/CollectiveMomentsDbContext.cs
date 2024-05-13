using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollectiveMomentsServerBL.Models;

public partial class CollectiveMomentsDbContext : DbContext
{
    public CollectiveMomentsDbContext()
    {
    }

    public CollectiveMomentsDbContext(DbContextOptions<CollectiveMomentsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumMedium> AlbumMedia { get; set; }

    public virtual DbSet<MediaItem> MediaItems { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=CollectiveMomentsDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Album__3214EC27164D3B8C");

            entity.ToTable("Album");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AlbumCover).HasMaxLength(100);
            entity.Property(e => e.AlbumTitle).HasMaxLength(30);
            entity.Property(e => e.Latitude).HasMaxLength(30);
            entity.Property(e => e.Longitude).HasMaxLength(30);
        });

        modelBuilder.Entity<AlbumMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AlbumMed__3214EC27BE31147B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Albumid).HasColumnName("albumid");
            entity.Property(e => e.Mediaurl)
                .HasMaxLength(250)
                .HasColumnName("mediaurl");

            entity.HasOne(d => d.Album).WithMany(p => p.AlbumMedia)
                .HasForeignKey(d => d.Albumid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumMedia_ToAlbum");
        });

        modelBuilder.Entity<MediaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaIte__3214EC07FEF5C08B");

            entity.ToTable("MediaItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.MediaId).HasColumnName("MediaID");

            entity.HasOne(d => d.Album).WithMany(p => p.MediaItems)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_MediaItem_Album");

            entity.HasOne(d => d.Media).WithMany(p => p.MediaItems)
                .HasForeignKey(d => d.MediaId)
                .HasConstraintName("FK_MediaItem_Media");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Media__3214EC27B6B5F847");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Sources).HasMaxLength(100);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC2769445E12");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Album).WithMany(p => p.Members)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_UsersAlbum_Album");

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UsersAlbum_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27C6B5B4B2");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.Passwrd).HasMaxLength(30);
            entity.Property(e => e.ProfilePicture).HasMaxLength(30);
            entity.Property(e => e.UserName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
