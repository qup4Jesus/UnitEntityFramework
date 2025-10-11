
using Microsoft.EntityFrameworkCore;
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.DAL
{
    public class MyAppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set;}
        public MyAppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC-GAMEROCK\SQLEXPRESS;Database=EF;Trusted_Connection=true;TrustServerCertificate=True;");
        }
    }
}
