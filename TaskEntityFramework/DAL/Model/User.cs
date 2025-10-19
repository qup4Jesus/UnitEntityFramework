
namespace TaskEntityFramework.DAL.Model
{
    /// <summary>
    /// Данная модель является отображением таблицы Users в БД.
    /// <Id> Индентификаор </Id>
    /// <Name> Имя пользователя </Name>
    /// <Email> Email пользователя </Email>
    /// </summary>
    internal class User : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
    }
}
