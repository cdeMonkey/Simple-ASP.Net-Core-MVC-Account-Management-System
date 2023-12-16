using _netCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _netCoreWebApp.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base (contextOptions) 
        {
        }

        public DbSet<UsersModel> users { get; set; }
    }
}
