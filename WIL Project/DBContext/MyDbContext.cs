using Microsoft.EntityFrameworkCore;
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

            // Define relationships and constraints
            modelBuilder.Entity<DiscountVoucher>()
                .HasMany(d => d.Redemptions) // DiscountVoucher has many Redemptions
                .WithOne(r => r.DiscountVoucher) // Each Redemption belongs to one DiscountVoucher
                .HasForeignKey(r => r.Code); // Foreign key for Redemption

            // Define relationships for other entities as needed

            modelBuilder.Entity<EventInformation>()
                .HasMany(e => e.Reviews) // EventInformation has many Reviews
                .WithOne(r => r.EventInformation) // Each Review belongs to one EventInformation
                .HasForeignKey(r => r.EventID); // Foreign key for Review

            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.EventInformation) // SessionInformation has one EventInformation
                .WithMany(e => e.Sessions) // EventInformation can have many Sessions
                .HasForeignKey(s => s.EventID); // Foreign key for SessionInformation
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
