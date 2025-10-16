
namespace TaskEntityFramework.DAL.Model.DataTransferObject
{
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
