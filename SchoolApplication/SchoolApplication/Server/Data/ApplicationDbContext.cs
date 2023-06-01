using Microsoft.EntityFrameworkCore;
using SchoolApplication.Shared;

namespace SchoolApplication.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Parent> Parent { get; set; }
        public DbSet<Student> student { get; set; }
    
    }
}
