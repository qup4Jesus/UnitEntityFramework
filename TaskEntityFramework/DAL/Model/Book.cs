
namespace TaskEntityFramework.DAL.Model
{
    internal class Book : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
