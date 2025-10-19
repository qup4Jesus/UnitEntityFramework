
namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
    /// <summary>
    /// Данная модель является отображением Join двух таблиц (DescriptionBook) и (Author)
    /// <Id> Индентификатор </Id>
    /// <DescriptionBookId> Индентификатор описания книги </DescriptionBookId>
    /// <Description> Описание </Description>
    /// <Genre> Жанр </Genre>
    /// <AuthorId> Индентификатор автора </AuthorId>
    /// <Name> Имя автора </Name>
    /// <YearBirth> Годы жизни с </YearBirth>
    /// <YearDeath> Годы жизни по </YearDeath>
    /// </summary>
    internal class DescriptionBookAuthorDto : Table
    {
        public int Id { get; set; }
        public int DescriptionBookId { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateOnly YearBirth { get; set; }
        public DateOnly YearDeath { get; set; }
    }
}
