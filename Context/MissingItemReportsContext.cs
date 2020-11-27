using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Models;
#nullable disable

namespace API.Context
{
    public partial class MissingItemReportsContext : DbContext
    {
        public MissingItemReportsContext()
        {
        }

        public MissingItemReportsContext(DbContextOptions<MissingItemReportsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MissingItemManufacturer> MissingItemManufacturers { get; set; }
        public virtual DbSet<MissingItemManufacturerType> MissingItemManufacturerTypes { get; set; }
        public virtual DbSet<MissingItemReport> MissingItemReports { get; set; }
        public virtual DbSet<MissingItemReportComment> MissingItemReportComments { get; set; }
        public virtual DbSet<MissingItemStatus> MissingItemStatuses { get; set; }
        public virtual DbSet<MissingItemType> MissingItemTypes { get; set; }
        public virtual DbSet<Reporter> Reporters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RLSFT20002\\SQLEXPRESS;Database=MissingItemReports;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MissingItemManufacturer>(entity =>
            {
                entity.ToTable("MissingItemManufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MissingItemManufacturerType>(entity =>
            {
                entity.HasKey(e => new { e.TypeId, e.ManufacturerId });

                entity.ToTable("MissingItemManufacturerType");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.MissingItemManufacturerTypes)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_MissingItemManufacturerType_Manufacturer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.MissingItemManufacturerTypes)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_MissingItemManufacturerType_Type");
            });

            modelBuilder.Entity<MissingItemReport>(entity =>
            {
                entity.ToTable("MissingItemReport");

                entity.Property(e => e.DateLost).HasColumnType("date");

                entity.Property(e => e.ProductionNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.MissingItemReports)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MissingItemReport_Manufacturer");

                entity.HasOne(d => d.Reporter)
                    .WithMany(p => p.MissingItemReports)
                    .HasForeignKey(d => d.ReporterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MissingItemReport_Reporter");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MissingItemReports)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MissingItemReport_Status");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.MissingItemReports)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MissingItemReport_Type");
            });

            modelBuilder.Entity<MissingItemReportComment>(entity =>
            {
                entity.ToTable("MissingItemReportComment");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.MissingItemReportComment)
                    .HasForeignKey<MissingItemReportComment>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MissingItemReportComment_MissingItemReport");
            });

            modelBuilder.Entity<MissingItemStatus>(entity =>
            {
                entity.ToTable("MissingItemStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MissingItemType>(entity =>
            {
                entity.ToTable("MissingItemType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reporter>(entity =>
            {
                entity.ToTable("Reporter");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
