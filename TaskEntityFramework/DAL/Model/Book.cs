
namespace TaskEntityFramework.DAL.Model
{
    internal class Book : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Внешний ключ
        public int UserId { get; set; }

        // Навигационное свойство
        public User User { get; set; }
    }
}
