namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
    internal class BookDescriptionBookDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DescriptionBookId { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int UserId { get; set; }
        public int AuthorId { get; set; }
    }
}
