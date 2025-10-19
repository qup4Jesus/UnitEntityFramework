
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    /// <summary>
    /// Данный класс предназначен для выполнения запрососв к БД (сущность Users)
    /// </summary>
    internal class UserRequest : Requests<User, User>
    {
        public override List<User> Find(int whereValue)
        {
            // Выполняем запрос по поиску пользоватлей у которых Id = whereValue.
            using (_db = new MyAppContext())
                return _db.Users.Where(u => u.Id == whereValue).ToList();
        }

        public override List<User> Find(string whereValue, string nameColumn)
        {
            // Выполняем запрос по поиску пользователей, где столбец равен nameColumn, 
            // а искомое значение равно whereValue
            using (_db = new MyAppContext())
                switch (nameColumn)
            {
                case "Name":
                // Поиск по столбцу "Name"
                    return _db.Users.Where(u => u.Name == whereValue).ToList();
                case "Email":
                // Поиск по столбцу "Email"
                    return _db.Users.Where(u => u.Email == whereValue).ToList();
                default:
                // Иначе Error
                    return null;
            }
        }

        public override User FindFirst()
        {
            // Выполняем запрос по поиску первого пользователя в таблице
            using (_db = new MyAppContext())
                return _db.Users.First();
        }

        public override List<User> Join()
        {
            // Выполняем запрос по присоединение. Которого нет, поэтому возвращаем null
            using (_db = new MyAppContext())
                return null;
        }

        public override int Sum()
        {
            // Выполняем запрос по нахождению суммы Id-шников. Кто-бы знал зачем?
            using (_db = new MyAppContext())
                return _db.Users.Sum(u => u.Id);
        }
    }
}
