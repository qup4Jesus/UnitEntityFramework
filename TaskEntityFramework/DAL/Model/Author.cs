
namespace TaskEntityFramework.DAL.Model
{
    internal class Author : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearBirth { get; set; }
        public DateTime YearDeath { get; set; }
    }
}
