namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
    /// <summary>
    /// Данная модель является отображением Join двух таблиц (DescriptionBook) и (Book)
    /// <Id> Индентификатор </Id>
    /// <BookId> Индентификатор книги </BookId>
    /// <BookName> Название книги </BookName>
    /// <ReleaseDate> Дата выхода книги </ReleaseDate>
    /// <DescriptionBookId> Индентификатор описания книги </DescriptionBookId>
    /// <Description> Описание </Description>
    /// <Genre> Жанр </Genre>
    /// <UserId> Индентификатор пользователя </UserId>
    /// <AuthorId> Индентификатор автора </AuthorId>
    /// </summary>
    internal class BookDescriptionBookDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int DescriptionBookId { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int UserId { get; set; }
        public int AuthorId { get; set; }
    }
}
