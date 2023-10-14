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
