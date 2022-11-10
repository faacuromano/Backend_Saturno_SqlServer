using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Saturno_Backend.Data.Models;

namespace Saturno_Backend.Data;

public partial class SaturnoContext : DbContext
{
    public SaturnoContext()
    {
    }

    public SaturnoContext(DbContextOptions<SaturnoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Saturno;Trusted_connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC271B80ACB9");

            entity.ToTable("Administrator");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Pasword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("RegDATE");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC2751139BE4");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PhotoProfile)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC27308380DB");

            entity.ToTable("Professional");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BannerPhoto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PerfilPhoto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Serivce__3214EC2703257113");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Turn__3214EC27FC8CB724");

            entity.ToTable("Turn");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProfessionalId).HasColumnName("ProfessionalID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Turns)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turn__ClientID__2E1BDC42");

            entity.HasOne(d => d.ProfessionalNavigation).WithMany(p => p.Turns)
                .HasForeignKey(d => d.ProfessionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turn__Profession__2F10007B");

            entity.HasOne(d => d.ServiceNavigation).WithMany(p => p.Turns)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Turn__ServiceID__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
