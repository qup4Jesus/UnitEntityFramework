
namespace UnitEntityFramework.DAL.Model
{
    public class UserCredentials : Table
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Внешний ключ
        public int UserId { get; set; }
        
        // Навигационное свойство
        public User User { get; set; }
    }
}
