
using Microsoft.EntityFrameworkCore;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL
{
    internal class MyAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<DescriptionBook> DescriptionBooks { get; set;}
        public DbSet<Author> Author { get; set; }

        public MyAppContext()
        {
            Database.EnsureCreated();
        }

        public MyAppContext(string writeUpdateBase)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PC-GAMEROCK\SQLEXPRESS;Database=Library;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
