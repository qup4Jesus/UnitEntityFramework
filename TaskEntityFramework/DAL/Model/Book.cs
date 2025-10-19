
namespace TaskEntityFramework.DAL.Model
{
    /// <summary>
    /// Данная модель является отображением таблицы Books в БД.
    /// <Id> Индентификатор </Id>
    /// <Name> Название книги </Name>
    /// <ReleaseDate> Дата выхода книги </ReleaseDate>
    /// <UserId> Индентифкатор пользователя </UserId>
    /// <DescriptionId> Индентификатор описания</DescriptionId>
    /// <DescriptionBook> Сущности описания книги </DescriptionBook>
    /// <User> Сущности пользователей </User>
    /// </summary>
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
