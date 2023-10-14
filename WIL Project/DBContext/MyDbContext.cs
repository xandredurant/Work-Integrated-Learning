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

            // Define the relationships and constraints
            modelBuilder.Entity<DiscountVoucher>()
            .HasMany(d => d.Redemptions)
            .WithMany(r => r.DiscountVouchers)
            .UsingEntity<Dictionary<string, object>>(
                "DiscountVoucherRedemption",
                j => j
                    .HasOne<Redemption>()
                    .WithMany()
                    .HasForeignKey("RedemptionId")
                    .HasConstraintName("FK_DiscountVoucherRedemption_RedemptionId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<DiscountVoucher>()
                    .WithMany()
                    .HasForeignKey("DiscountVoucherId")
                    .HasConstraintName("FK_DiscountVoucherRedemption_DiscountVoucherId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("DiscountVoucherId", "RedemptionId");
                    j.HasIndex("RedemptionId");
                });
            
            modelBuilder.Entity<DiscountVoucherRedemption>()
                .HasKey(dvr => new { dvr.RedemptionID, dvr.UserID });

            modelBuilder.Entity<DiscountVoucherRedemption>()
                .HasOne(dvr => dvr.Redemption)
                .WithMany(r => r.DiscountVoucherRedemptions)
                .HasForeignKey(dvr => dvr.RedemptionID);

            modelBuilder.Entity<DiscountVoucherRedemption>()
                .HasOne(dvr => dvr.DiscountVoucher)
                .WithMany(d => d.DiscountVoucherRedemptions)
                .HasForeignKey(dvr => dvr.UserID);

            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventID);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EventID);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(r => r.EventInformation)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EventID);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(r => r.SessionInformation)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.SessionID);

            modelBuilder.Entity<ReviewRating>()
                .HasOne(r => r.UserInfo)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.EventInformation)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventID);

            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.SpeakerInformation)
                .WithMany(sp => sp.Sessions)
                .HasForeignKey(s => s.SpeakerID);

            modelBuilder.Entity<SpeakerInformation>()
                .HasMany(s => s.Sessions)
                .WithOne(session => session.SpeakerInformation)
                .HasForeignKey(session => session.SpeakerID);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.EventInformation)
                .WithMany(e => e.Surveys)
                .HasForeignKey(s => s.EventID);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.SessionInformation)
                .WithMany(session => session.Surveys)
                .HasForeignKey(s => s.SessionID);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.UserInfo)
                .WithMany(u => u.Surveys)
                .HasForeignKey(s => s.UserID);

            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.UserInfo)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<UserInfo>()
                .HasMany(u => u.Surveys)
                .WithOne(s => s.UserInfo)
                .HasForeignKey(s => s.UserID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
