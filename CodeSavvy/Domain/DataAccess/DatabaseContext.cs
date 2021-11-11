using CodeSavvy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
