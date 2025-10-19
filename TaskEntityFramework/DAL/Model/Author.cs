
namespace TaskEntityFramework.DAL.Model
{
    /// <summary>
    /// Данная таблица являетя отображением Author в БД.
    /// <Id> Индентификатор </Id>
    /// <Name> Имя автора </Name>
    /// <YearBirth> Годы жизни автора с </YearBirth>
    /// <YearDeath> Годы жизни автор по </YearDeath>
    /// </summary>
    internal class Author : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly YearBirth { get; set; }
        public DateOnly YearDeath { get; set; }
    }
}
