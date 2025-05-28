using Microsoft.EntityFrameworkCore;

namespace Kenouz.Data
{
    public class Logged_in_Users_DbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=KenouzDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public Logged_in_Users_DbContext(DbContextOptions<Logged_in_Users_DbContext> options) : base(options)
        {
        }
        public DbSet<Logged_in_Users> Logged_In_Users { get; set; }
        public DbSet<DeactivatedUser> DeactivatedUsers { get; set; }
    }
}
