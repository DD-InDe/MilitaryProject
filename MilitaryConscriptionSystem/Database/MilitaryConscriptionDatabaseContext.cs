using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MilitaryConscriptionSystem.Database;

public partial class MilitaryConscriptionDatabaseContext : DbContext
{
    public MilitaryConscriptionDatabaseContext()
    {
    }

    public MilitaryConscriptionDatabaseContext(DbContextOptions<MilitaryConscriptionDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Conscript> Conscripts { get; set; }

    public virtual DbSet<ConscriptDocument> ConscriptDocuments { get; set; }

    public virtual DbSet<ConscriptionCommission> ConscriptionCommissions { get; set; }

    public virtual DbSet<ConscriptionCommissionEmployee> ConscriptionCommissionEmployees { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MedicalCommission> MedicalCommissions { get; set; }

    public virtual DbSet<MilitaryDraftNotice> MilitaryDraftNotices { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LEGION;Database=MilitaryConscriptionDatabase;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryKey).HasName("PK__Category__76B0FE41E02E4EE7");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryKey)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<Conscript>(entity =>
        {
            entity.HasKey(e => e.PassportId).HasName("PK__Conscrip__185653D0CB9CEB04");

            entity.ToTable("Conscript");

            entity.Property(e => e.PassportId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);

            entity.HasOne(d => d.Passport).WithOne(p => p.Conscript)
                .HasForeignKey<Conscript>(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conscript__Passp__5DCAEF64");
        });

        modelBuilder.Entity<ConscriptDocument>(entity =>
        {
            entity.HasKey(e => e.ConscriptDocumentId).HasName("PK__Conscrip__B9BC4787808059DC");

            entity.ToTable("ConscriptDocument");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.DocumentName).HasMaxLength(200);

            entity.HasOne(d => d.Conscript).WithMany(p => p.ConscriptDocuments)
                .HasForeignKey(d => d.ConscriptId)
                .HasConstraintName("FK__Conscript__Consc__6EF57B66");
        });

        modelBuilder.Entity<ConscriptionCommission>(entity =>
        {
            entity.HasKey(e => e.ConscriptionCommissionId).HasName("PK__Conscrip__834C2A3E52A8F2B2");

            entity.ToTable("ConscriptionCommission");
        });

        modelBuilder.Entity<ConscriptionCommissionEmployee>(entity =>
        {
            entity.HasKey(e => e.ConscriptionCommissionEmployeeId).HasName("PK__Conscrip__9B15B2A2C349A80E");

            entity.ToTable("ConscriptionCommissionEmployee");

            entity.HasOne(d => d.ConscriptionCommissionNavigation).WithMany(p => p.ConscriptionCommissionEmployees)
                .HasForeignKey(d => d.ConscriptionCommission)
                .HasConstraintName("FK__Conscript__Consc__628FA481");

            entity.HasOne(d => d.Employee).WithMany(p => p.ConscriptionCommissionEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Conscript__Emplo__6383C8BA");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.PassportId).HasName("PK__Employee__185653D0F7A8A307");

            entity.ToTable("Employee");

            entity.Property(e => e.PassportId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(20);

            entity.HasOne(d => d.Passport).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Passpo__59063A47");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Employee__Positi__5812160E");
        });

        modelBuilder.Entity<MedicalCommission>(entity =>
        {
            entity.HasKey(e => e.MilitaryDraftNoticeId).HasName("PK__MedicalC__FF7E70357CEEA1E8");

            entity.ToTable("MedicalCommission");

            entity.Property(e => e.MilitaryDraftNoticeId).ValueGeneratedNever();
            entity.Property(e => e.CategoryKey)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Confirmed).HasDefaultValue(false);
            entity.Property(e => e.Diagnoses).HasMaxLength(500);
            entity.Property(e => e.HealthComplaints).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(200);

            entity.HasOne(d => d.CategoryKeyNavigation).WithMany(p => p.MedicalCommissions)
                .HasForeignKey(d => d.CategoryKey)
                .HasConstraintName("FK__MedicalCo__Categ__6A30C649");

            entity.HasOne(d => d.MilitaryDraftNotice).WithOne(p => p.MedicalCommission)
                .HasForeignKey<MedicalCommission>(d => d.MilitaryDraftNoticeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MedicalCo__Milit__6C190EBB");
        });

        modelBuilder.Entity<MilitaryDraftNotice>(entity =>
        {
            entity.HasKey(e => e.MilitaryDraftNoticeId).HasName("PK__Military__FF7E7035374AB962");

            entity.ToTable("MilitaryDraftNotice");

            entity.Property(e => e.Address).HasMaxLength(200);

            entity.HasOne(d => d.ConscriptCommission).WithMany(p => p.MilitaryDraftNotices)
                .HasForeignKey(d => d.ConscriptCommissionId)
                .HasConstraintName("FK__MilitaryD__Consc__6754599E");

            entity.HasOne(d => d.Conscript).WithMany(p => p.MilitaryDraftNotices)
                .HasForeignKey(d => d.ConscriptId)
                .HasConstraintName("FK__MilitaryD__Consc__66603565");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.PassportId).HasName("PK__Passport__185653D0937FE1CD");

            entity.ToTable("Passport");

            entity.Property(e => e.IssuedBy).HasMaxLength(200);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A79FA276DED");

            entity.ToTable("Position");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
