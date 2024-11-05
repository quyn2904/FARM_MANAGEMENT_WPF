using System;
using System.Collections.Generic;
using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories;

public partial class MyFarmContext : DbContext
{
    public MyFarmContext()
    {
    }

    public MyFarmContext(DbContextOptions<MyFarmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cage> Cages { get; set; }

    public virtual DbSet<Cattle> Cattles { get; set; }

    public virtual DbSet<CattleByCage> CattleByCages { get; set; }

    public virtual DbSet<CattleDrug> CattleDrugs { get; set; }

    public virtual DbSet<CattleFoodSchedule> CattleFoodSchedules { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffByCage> StaffByCages { get; set; }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }

    public bool IsAdmin(string email, string password)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        string adminEmail = configuration["AdminAccount:Email"];
        string adminPassword = configuration["AdminAccount:Password"];

        return adminEmail == email && adminPassword == password;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cage>(entity =>
        {
            entity.ToTable("Cage");

            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cattle>(entity =>
        {
            entity.ToTable("Cattle");

            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<CattleByCage>(entity =>
        {
            entity.ToTable("CattleByCage");

            entity.Property(e => e.CattleByCageId).HasColumnName("CattleByCageID");
            entity.Property(e => e.CageId).HasColumnName("CageID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.EndingTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Ending_Timestamp");
            entity.Property(e => e.StartingTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Starting_Timestamp");

            entity.HasOne(d => d.Cage).WithMany(p => p.CattleByCages)
                .HasForeignKey(d => d.CageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CattleByCage_Cage");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleByCages)
                .HasForeignKey(d => d.CattleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CattleByCage_Cattle");
        });

        modelBuilder.Entity<CattleDrug>(entity =>
        {
            entity.ToTable("CattleDrug");

            entity.Property(e => e.CattleDrugId).HasColumnName("CattleDrugID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleDrugs)
                .HasForeignKey(d => d.CattleId)
                .HasConstraintName("FK_CattleDrug_Cattle");

            entity.HasOne(d => d.Drug).WithMany(p => p.CattleDrugs)
                .HasForeignKey(d => d.DrugId)
                .HasConstraintName("FK_CattleDrug_Drug");
        });

        modelBuilder.Entity<CattleFoodSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.ToTable("CattleFoodSchedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.FeedingTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FoodId).HasColumnName("FoodID");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleFoodSchedules)
                .HasForeignKey(d => d.CattleId)
                .HasConstraintName("FK_CattleFoodSchedule_Cattle");

            entity.HasOne(d => d.Food).WithMany(p => p.CattleFoodSchedules)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK_CattleFoodSchedule_Food");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.ToTable("Drug");

            entity.Property(e => e.DrugId).HasColumnName("DrugID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsageInstructions).HasColumnType("text");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Food");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StaffByCage>(entity =>
        {
            entity.ToTable("StaffByCage");

            entity.Property(e => e.StaffByCageId).HasColumnName("StaffByCageID");
            entity.Property(e => e.AssignedDate).HasColumnType("datetime");
            entity.Property(e => e.CageId).HasColumnName("CageID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.WorkingTime)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Cage).WithMany(p => p.StaffByCages)
                .HasForeignKey(d => d.CageId)
                .HasConstraintName("FK_StaffByCage_Cage");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffByCages)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_StaffByCage_Staff");
        });

        modelBuilder.Entity<Sysdiagram>(entity =>
        {
            entity.HasKey(e => e.DiagramId);

            entity.ToTable("sysdiagrams");

            entity.HasIndex(e => new { e.PrincipalId, e.Name }, "UK_principal_name").IsUnique();

            entity.Property(e => e.DiagramId).HasColumnName("diagram_id");
            entity.Property(e => e.Definition).HasColumnName("definition");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
