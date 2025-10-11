
namespace TaskEntityFramework.DAL.Model
{
    internal class DescriptionBook : Table
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        // Внешний ключ
        public int AuthorId { get; set; }
        // Навигационное свойство
        public Author Author { get; set; }
    }
}
