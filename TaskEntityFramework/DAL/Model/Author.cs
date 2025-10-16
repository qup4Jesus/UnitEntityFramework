
namespace TaskEntityFramework.DAL.Model
{
    internal class Author : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly YearBirth { get; set; }
        public DateOnly YearDeath { get; set; }
    }
}
