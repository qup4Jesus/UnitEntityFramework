using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    internal class UserRepository : AbstractRepository<User>
    {
        public override void Add(List<User> newUsers)
        {
            using (_db = new MyAppContext())
            {
                foreach (var user in newUsers)
                {
                    // Добавление одиночного пользователя, для добавление нескольких
                    // пользователей используем AddRange(element1, ... ,element54);
                    _db.Users.Add(user);
                }

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db = new MyAppContext())
            {
                // Удаление конкретного пользователя по Id
                var user = _db.Users.Find(id);

                // Удаление одиночного пользователя для удаления нескольких
                // пользователей используем RemoveRange(element1, ... ,element72);
                _db.Users.Remove(user);

                _db.SaveChanges();
            }
        }

        public override List<User> ReadAll()
        {
            using (_db = new MyAppContext())
            {
                // Получение всех существующих пользователей в БД
                return _db.Users.ToList();
            }
        }

        public override User ReadOne(int id)
        {
            using (_db = new MyAppContext())
            {
                // Конкретного пользователя по Id
                var user = _db.Users.Find(id);

                return user;
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db = new MyAppContext())
            {
                // Изменение пользователя по его Id
                var user = _db.Users.Find(id);

                switch (nameColumn)
                {
                    case nameof(user.Name):
                        user.Name = value;
                        break;
                    case nameof(user.Email):
                        user.Email = value;
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}