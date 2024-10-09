using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegisterAndLogin.Models;

public partial class LogInAndSignUpContext : DbContext
{
    public LogInAndSignUpContext()
    {
    }

    public LogInAndSignUpContext(DbContextOptions<LogInAndSignUpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LogInAndSignUp> LogInAndSignUps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogInAndSignUp>(entity =>
        {
            entity.ToTable("LogInAndSignUp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
