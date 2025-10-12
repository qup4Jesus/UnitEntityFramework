
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
        public DateTime YearBirth { get; set; }
        public DateTime YearDeath { get; set; }
    }
}
