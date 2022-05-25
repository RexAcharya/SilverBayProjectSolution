/*using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SilvarBayAPI.Temp;

#nullable disable

namespace SilvarBayAPI.Models
{
    public partial class SilverBayPortalDBContext : DbContext
    {
        public SilverBayPortalDBContext()
        {
        }

        public SilverBayPortalDBContext(DbContextOptions<SilverBayPortalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAndVendor> ClientAndVendors { get; set; }
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Recruiter> Recruiters { get; set; }
        public virtual DbSet<UserInvitation> UserInvitations { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<WorkSheet> WorkSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SilverBayPortalDB;Trusted_Connection=True;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ClientAndVendor>(entity =>
            {
                entity.HasKey(e => e.ClientVendorId);

                entity.HasIndex(e => e.ClientId, "IX_ClientAndVendors_ClientId");

                entity.HasIndex(e => e.VendorId, "IX_ClientAndVendors_VendorId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAndVendors)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ClientAndVendors)
                    .HasForeignKey(d => d.VendorId);
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Consultants_UserId")
                    .IsUnique()
                    .HasFilter("([UserId] IS NOT NULL)");

                entity.Property(e => e.ConsultantId).HasColumnName("consultantId");

                entity.Property(e => e.FlagStat).HasColumnName("flagStat");

                entity.Property(e => e.UserPosition).HasColumnName("userPosition");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Consultant)
                    .HasForeignKey<Consultant>(d => d.UserId);
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.HasIndex(e => e.VendorId, "IX_Recruiters_VendorId");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Recruiters)
                    .HasForeignKey(d => d.VendorId);
            });

            modelBuilder.Entity<UserInvitation>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserInvitations_UserId")
                    .IsUnique()
                    .HasFilter("([UserId] IS NOT NULL)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserInvitation)
                    .HasForeignKey<UserInvitation>(d => d.UserId);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VendorPhone)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WorkSheet>(entity =>
            {
                entity.HasIndex(e => e.ClientId, "IX_WorkSheets_ClientId")
                    .IsUnique();

                entity.HasIndex(e => e.RecruiterId, "IX_WorkSheets_RecruiterId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_WorkSheets_UserId")
                    .IsUnique()
                    .HasFilter("([UserId] IS NOT NULL)");

                entity.HasIndex(e => e.VendorId, "IX_WorkSheets_VendorId")
                    .IsUnique();

                entity.Property(e => e.JobLocation).HasColumnName("jobLocation");

                entity.Property(e => e.JobStatus).HasColumnName("jobStatus");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.VisaStatus).HasColumnName("visa_status");

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.WorkSheet)
                    .HasForeignKey<WorkSheet>(d => d.ClientId);

                entity.HasOne(d => d.Recruiter)
                    .WithOne(p => p.WorkSheet)
                    .HasForeignKey<WorkSheet>(d => d.RecruiterId);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.WorkSheet)
                    .HasForeignKey<WorkSheet>(d => d.UserId);

                entity.HasOne(d => d.Vendor)
                    .WithOne(p => p.WorkSheet)
                    .HasForeignKey<WorkSheet>(d => d.VendorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
*/