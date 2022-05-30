using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvarBayAPI.Authentication;
using SilvarBayAPI.Models;


namespace SilvarBayAPI.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<AspNetUser>//DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>

        /*public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }*/
        /// </summary>

        public virtual DbSet<VendorModel> Vendors { get; set; }
        public virtual DbSet<UserInvitationModel> UserInvitations { get; set; }
        public virtual DbSet<ConsultantModel> Consultants {get;set;}
        public virtual DbSet<RecruiterModel> Recruiters { get; set; } 
        public virtual DbSet<ClientModel> Clients { get; set; }
        public virtual DbSet<Client_VendorModel> ClientAndVendors { get; set; }
        public virtual DbSet<WorkSheetModel> WorkSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SilverBayPortalDB;Trusted_Connection=True;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           /* builder.Entity<Recruiter>()
                .Property<int>("VendorForeignKey");*/
           
            base.OnModelCreating(builder);
       
        builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            builder.Entity<VendorModel>(entity =>
            {
                entity.Property(e => e.VendorName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.VendorPhone)
                .IsRequired()
                .HasMaxLength(100);


            });

            builder.Entity<RecruiterModel>(b =>
            {
                b.HasOne(e=>e.Vendor)
                    .WithMany(a =>a.RecruiterList)
                    .HasForeignKey("VendorId")
                    .OnDelete(DeleteBehavior.NoAction);
            });



            //////
            builder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            builder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            builder.Entity<AspNetUser>(entity =>
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

            builder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });


            builder.Entity<AspNetUserLogin>(entity =>
            {
                //entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            /*The INSERT statement conflicted with the FOREIGN KEY constraint "FK_AspNetUserRoles_AspNetRoles_RoleId"*/
            builder.Entity<AspNetUserRole>(entity =>
            {
                //entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");
                

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            builder.Entity<AspNetUserToken>(entity =>
            {
               // entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);

                
            });

           

            builder.Entity<WorkSheetModel>(entity =>
            {
                entity.HasOne(d => d.AUser)
                .WithMany(p => p.WorkSheets)
                .HasForeignKey("UserId");

            });
            /*builder.Entity<ConsultantModel>(entity =>
            {
                entity.HasOne(d => d.AUser)
                .WithOne(p => p.Consultant)
                .HasForeignKey<AspNetUser>(d => d.Id);
                ;

            });

            builder.Entity<UserInvitationModel>(entity =>
            {
                entity.HasOne(d => d.AUser)
                .WithOne(p=>p.userinvitation)
                .HasForeignKey<AspNetUser>(d=>d.Id);

            });*/
            //////
            /*base.OnModelCreating(builder);*/
            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
