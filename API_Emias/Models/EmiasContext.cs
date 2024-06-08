using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Emias.Models;

public partial class EmiasContext : DbContext
{
    public EmiasContext()
    {
    }

    public EmiasContext(DbContextOptions<EmiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminProf> AdminProfs { get; set; }

    public virtual DbSet<AnalysDocument> AnalysDocuments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<StatusType> StatusTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminProf>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__AdminPro__4C3F97F48B9A1234");

            entity.ToTable("AdminProf");

            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.NameAdmin).HasMaxLength(50);
            entity.Property(e => e.PatronymicAdmin).HasMaxLength(50);
            entity.Property(e => e.SurnameAdmin).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__AnalysDo__ECE24AAB2879D420");

            entity.ToTable("AnalysDocument");

            entity.Property(e => e.IdAppointment).ValueGeneratedNever();
            entity.Property(e => e.Rtf).HasColumnType("text");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__ECE24AAB808A17A3");

            entity.Property(e => e.Oms).HasColumnName("OMS");
        });

        modelBuilder.Entity<AppointmentDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__ECE24AAB12AA59F8");

            entity.ToTable("AppointmentDocument");

            entity.Property(e => e.IdAppointment).ValueGeneratedNever();
            entity.Property(e => e.Rtf).HasColumnType("text");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PK__Directio__7780E2B217C61185");

            entity.Property(e => e.Oms).HasColumnName("OMS");

        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__F838DB3E78746476");

            entity.ToTable("Doctor");

            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.NameDoctor).HasMaxLength(50);
            entity.Property(e => e.PatronymicDoctor).HasMaxLength(50);
            entity.Property(e => e.SurnameDoctor).HasMaxLength(50);
            entity.Property(e => e.WorkAddress).HasMaxLength(255);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Oms).HasName("PK__Patient__CB396B8B41CA4E28");

            entity.ToTable("Patient");

            entity.Property(e => e.Oms)
                .ValueGeneratedNever()
                .HasColumnName("OMS");
            entity.Property(e => e.AddressPatient).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LivingAddress).HasMaxLength(255);
            entity.Property(e => e.NamePatient).HasMaxLength(50);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.PatronymicPatient).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
            entity.Property(e => e.SurnamePatient).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Research__ECE24AAB11E32500");

            entity.ToTable("ResearchDocument");

            entity.Property(e => e.IdAppointment).ValueGeneratedNever();
            entity.Property(e => e.Rtf).HasColumnType("text");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK__Speciali__5C8D4E6853DC04B5");

            entity.HasIndex(e => e.NameSpeciality, "UQ__Speciali__A22CB84661A6475E").IsUnique();

            entity.Property(e => e.NameSpeciality)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusType>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__StatusTy__B450643ACA3D892F");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
