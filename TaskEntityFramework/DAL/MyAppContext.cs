
using Microsoft.EntityFrameworkCore;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL
{
    internal class MyAppContext : DbContext
    {
        // Данное свойство отвечает за коллекцию сущностей (Users) талица (Users).
        public DbSet<User> Users { get; set; }

        // Данное свойство отвечает за коллекцию сущностей (Books) талица (Books).
        public DbSet<Book> Books { get; set; }

        // Данное свойство отвечает за коллекцию сущностей (DescriptionBooks) талица (DescriptionBooks).
        public DbSet<DescriptionBook> DescriptionBooks { get; set;}

        // Данное свойство отвечает за коллекцию сущностей (Author) талица (Author).
        public DbSet<Author> Author { get; set; }

        // Точка входа в БД.
        public MyAppContext()
        {
            Database.EnsureCreated();
        }

        // Конструктор пересоздания БД.
        public MyAppContext(string writeUpdateBase)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        // Настройка подключения к БД.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-8TG8MLQ2UED\SQLEXPRESS;Database=Library;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
