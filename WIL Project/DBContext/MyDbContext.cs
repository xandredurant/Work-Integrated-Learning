using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WIL_Project.Models;

namespace WIL_Project.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<EventInformation> EventInformation { get; set; }
        public DbSet<SessionInformation> SessionInformation { get; set; }
        public DbSet<SpeakerInformation> SpeakerInformation { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<DiscountVoucher> DiscountVoucher { get; set; }
        public DbSet<DiscountVoucherRedemption> DiscountVoucherRedemption { get; set; }
        public DbSet<ReviewRating> ReviewRating { get; set; }
        public DbSet<Survey> Survey { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the primary key for DiscountVoucher
            modelBuilder.Entity<DiscountVoucher>().HasKey(d => d.Code);

            // Define the primary key for DiscountVoucherRedemption
            modelBuilder.Entity<DiscountVoucherRedemption>().HasKey(d => d.RedemptionID);

            // Define the primary key for EventInformation
            modelBuilder.Entity<EventInformation>().HasKey(e => e.EventID);

            // Define the primary key for ReviewRating
            modelBuilder.Entity<ReviewRating>().HasKey(r => r.ReviewID);

            // Define the primary key for SessionInformation
            modelBuilder.Entity<SessionInformation>().HasKey(s => s.SessionID);

            // Define the primary key for SpeakerInformation
            modelBuilder.Entity<SpeakerInformation>().HasKey(s => s.SpeakerID);

            // Define the primary key for Survey
            modelBuilder.Entity<Survey>().HasKey(s => s.SurveyID);

            // Define the primary key for UserInfo
            modelBuilder.Entity<UserInfo>().HasKey(u => u.UserID);

            modelBuilder.Entity<DiscountVoucher>()
                .HasMany(d => d.Redemptions)
                .WithOne(r => r.DiscountVoucher)
                .HasForeignKey(r => r.Code);

            modelBuilder.Entity<DiscountVoucherRedemption>()
                .HasKey(dvr => new { dvr.RedemptionID, dvr.UserID });

            modelBuilder.Entity<SessionInformation>()
                .HasMany(s => s.Surveys)
                .WithOne(survey => survey.SessionInformation)
                .HasForeignKey(survey => survey.SessionID);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(r => r.EventInformation)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EventID);

            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.EventInformation)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventID);

            modelBuilder.Entity<EventInformation>()
                .HasMany(e => e.Surveys)
                .WithOne(survey => survey.EventInformation)
                .HasForeignKey(survey => survey.EventID);

            modelBuilder.Entity<EventInformation>()
                .HasMany(e => e.Reviews)
                .WithOne(review => review.EventInformation)
                .HasForeignKey(review => review.EventID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
