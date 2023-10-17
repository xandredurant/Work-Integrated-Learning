using Microsoft.EntityFrameworkCore;
using WIL_Project.Models;

namespace WIL_Project.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserProgram> Sessions { get; set; }
    }
}
