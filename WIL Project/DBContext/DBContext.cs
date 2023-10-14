using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace WIL_Project.DBContext
{
    public class DBContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<EventInformation> EventInformation { get; set; }
        public DbSet<SessionInformation> SessionInformation { get; set; }
        public DbSet<SpeakerInformation> SpeakerInformation { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<DiscountAndVoucher> DiscountAndVoucher { get; set; }
        public DbSet<DiscountAndVoucherRedemption> DiscountAndVoucherRedemption { get; set; }
        public DbSet<ReviewAndRating> ReviewAndRating { get; set; }
        public DbSet<Survey> Survey { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints here if needed
            modelBuilder.Entity<SessionInformation>()
                .HasOne(s => s.EventInformation)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventID);

            // Add other relationships and constraints as needed
        }
    }
}
