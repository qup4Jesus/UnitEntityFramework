
namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
    internal class BookUserDto : Table
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public int DescriptionBookId { get; set; }
    }
}
