
// using UnitEntityFramework.BLL.Exceptions;
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.DAL.Repositories
{
    internal class UserRepository : AbstractRepository<User>
    {
        public UserRepository() : base() { }

        public override void Add(List<User> newUsers)
        {
            using (_db)
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
            using (_db)
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
            using (_db)
            {
                // Получение всех существующих пользователей в БД
                return _db.Users.ToList();
            }
        }

        public override User ReadOne(int id)
        {
            using (_db)
            {
                // Конкретного пользователя по Id
                var user = _db.Users.Find(id);

                return user;
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db)
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
                    case nameof(user.Role):
                        user.Role = value;
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}