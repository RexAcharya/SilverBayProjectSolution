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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<VendorModel> Vendors { get; set; }
        public DbSet<UserInvitationModel> UserInvitations { get; set; }
        public DbSet<ConsultantModel> Consultants {get;set;}
        public DbSet<RecruiterModel> Recruiters { get; set; } 
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<Client_VendorModel> ClientAndVendors { get; set; }
        public DbSet<WorkSheetModel> WorkSheets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           /* builder.Entity<Recruiter>()
                .Property<int>("VendorForeignKey");*/

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

            

            /*builder.Entity<RecruiterModel>()
                .HasOne(p => p.Vendor)
                .WithMany(a => a.RecruiterList)
                .HasForeignKey("VendorId")
                .OnDelete(DeleteBehavior.NoAction);*/


            /*builder.Entity<Client_VendorModel>()
                .HasOne(v => v.vendor)
                .WithMany(a => a.cvlist);
                

            builder.Entity<Client_VendorModel>()
                .HasOne(v => v.client)
                .WithMany(a => a.cvlist);

            builder.Entity<WorkSheetModel>()
                .HasOne(v => v.recruiter);*/
            /*

            builder.Entity<WorkSheetModel>()
                .HasOne(v => v.client)*//*
                .WithOne();*//*;*/


/*
            builder.Entity<Client_VendorModel>()
                .HasOne(v => v.vendor)
                .WithMany(p => p.cvlist)
                .HasForeignKey("VendorID");
            builder.Entity<Client_VendorModel>()
                .HasOne(v => v.client)
                .WithMany(p => p.cvlist)
                .HasForeignKey("ClientID");*/


            base.OnModelCreating(builder);
        }
        //public DbSet<SilvarBayAPI.Models.BasicInfoModel> BasicInfoModel { get; set; }


    }
}
