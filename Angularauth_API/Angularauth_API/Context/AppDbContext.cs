using Angularauth_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Angularauth_API.Context
{
    public class AppDbContext: DbContext  //ctor 2 tabs
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
