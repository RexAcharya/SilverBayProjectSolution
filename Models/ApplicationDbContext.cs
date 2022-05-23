using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvarBayAPI.Authentication;

namespace SilvarBayAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<VendorModel> Vendors { get; set; }
        public DbSet<UserInvitationModel> UserInvitations { get; set; }
        public DbSet<UserModel> Consultants {get;set;}
        public DbSet<Recruiter> Recruiters { get; set; } 
        public DbSet<ClientModelk> Clients { get; set; }
        public DbSet<Client_VendorModel> ClientAndVedors { get; set; }
        public DbSet<WorkSheetModel> WorkSheets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VendorModel>(entity =>
            {
                entity.Property(e => e.VendorName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.VendorPhone)
                .IsRequired()
                .HasMaxLength(100);


            });

            base.OnModelCreating(builder);
        }


    }
}
