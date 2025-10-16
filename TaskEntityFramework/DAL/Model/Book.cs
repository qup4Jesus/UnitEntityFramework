
namespace TaskEntityFramework.DAL.Model
{
    internal class Book : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ReleaseDate { get; set; }

        // Внешний ключ
        public int UserId { get; set; } = 0;
        public int DescriptionBookId { get; set; }

        // Навигационное свойство
        public DescriptionBook DescriptionBook { get; set; }
        public User User { get; set; }
    }
}
