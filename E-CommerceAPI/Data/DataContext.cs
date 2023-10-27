using E_CommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
    }
}
