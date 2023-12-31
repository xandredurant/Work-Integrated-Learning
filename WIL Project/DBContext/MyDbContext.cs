﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WIL_Project.Models;

namespace WIL_Project.DBContext
{
    public class MyDbContext : IdentityDbContext<UserInfo>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<UserProgram> Sessions { get; set; }
        public DbSet<EventInformation> EventInformation { get; set; }
        public DbSet<SessionInformation> SessionInformation { get; set; }
        public DbSet<SpeakerInformation> SpeakerInformation { get; set; }
        public DbSet<DiscountVoucher> DiscountVoucher { get; set; }
        public DbSet<DiscountVoucherRedemption> DiscountVoucherRedemption { get; set; }
        public DbSet<ReviewRating> ReviewRating { get; set; }
        public DbSet<Survey> Survey { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProgram>().HasKey(d => d.BookingID);
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

            // Add any additional configuration or relationships for your entities here.
            modelBuilder.Entity<SessionInformation>()
        .HasOne(si => si.EventInformation)
        .WithMany(ei => ei.Sessions)
        .HasForeignKey(si => si.EventID)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(rr => rr.SessionInformation)
                .WithMany(si => si.ReviewRatings)
                .HasForeignKey(rr => rr.SessionID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
