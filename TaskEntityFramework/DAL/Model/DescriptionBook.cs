
namespace TaskEntityFramework.DAL.Model
{
    /// <summary>
    /// Данная модель является отображением таблицы DescriptionBook в БД.
    /// <Id> Индентификтор </Id>
    /// <Description> Описание </Description>
    /// <Genre> Жанр </Genre>
    /// <AuthorId> Индентификатор автора</AuthorId>
    /// <Author> Сущность автора </Author>
    /// </summary>
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
