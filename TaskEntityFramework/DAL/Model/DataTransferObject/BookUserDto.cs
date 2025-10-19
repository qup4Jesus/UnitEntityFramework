
namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
    /// <summary>
    /// Данная модель является отображением Join двух таблиц (Book) и (User)
    /// <Id> Индентификатор </Id>
    /// <BookId> Индентификатор книги </BookId>
    /// <BookName> Название книги </BookName>
    /// <ReleaseDate> Дата выхода книги </ReleaseDate>
    /// <UserId> Индентификатор пользователя </UserId>
    /// <UserName> Имя пользователя </UserName>
    /// <Email> Email пользователя </Email>
    /// <DescriptionBookId> Индентификатор описания книги </DescriptionBookId>
    /// </summary>
    internal class BookUserDto : Table
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public int DescriptionBookId { get; set; }
    }
}
