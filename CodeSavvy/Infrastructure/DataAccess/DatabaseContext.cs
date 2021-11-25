using CodeSavvy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeSavvy.Infrastructure.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Domain.Models.Application> Applications { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
