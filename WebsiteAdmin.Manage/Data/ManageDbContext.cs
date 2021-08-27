using Microsoft.EntityFrameworkCore;
using WebsiteAdmin.Manage.Data.Entities;

namespace WebsiteAdmin.Manage.Data
{
    public class ManageDbContext : DbContext
    {
        public ManageDbContext(DbContextOptions<ManageDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
