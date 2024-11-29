using Microsoft.EntityFrameworkCore;
using RegisterLoginApp_ASP_MVC.Models;

namespace RegisterLoginApp_ASP_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public required DbSet<User> Users { get; set; }
    }
}
