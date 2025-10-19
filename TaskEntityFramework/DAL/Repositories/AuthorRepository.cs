
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    /// <summary>
    /// Данный класс предназначен для работы непосредственно с БД для сущности Author
    /// </summary>
    internal class AuthorRepository : AbstractRepository<Author>
    {
        public override void Add(List<Author> newElements)
        {
            using (_db = new MyAppContext())
            {
                // Добавление одиночного автора, для добавление нескольких
                // авторов используем AddRange(element1, ... ,element54);
                _db.AddRange(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db = new MyAppContext())
            {
                // Удаление конкретного автора по Id
                var author = _db.Author.Find(id);

                // Удаление одиночного автора для удаления нескольких
                // авторов используем RemoveRange(element1, ... ,element72);
                _db.Author.Remove(author);

                _db.SaveChanges();
            }
        }

        public override List<Author> ReadAll()
        {
            using (_db = new MyAppContext())
            {
                // Получение всех существующих авторов в БД
                return _db.Author.ToList();
            }
        }

        public override Author ReadOne(int id)
        {
            using (_db = new MyAppContext())
            {
                // Получение конкретного автора по Id
                return _db.Author.Find(id);
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db = new MyAppContext())
            {
                // Изменение автора по его Id
                var author = _db.Author.Find(id);

                switch (nameColumn)
                {
                    // Изменение имени автора
                    case nameof(author.Name):
                        author.Name = value;
                        break;
                    // Изменение года рождения автора
                    case nameof(author.YearBirth):
                        author.YearBirth = DateOnly.Parse(value);
                        break;
                    // Изменение года смерти автора
                    case nameof(author.YearDeath):
                        author.YearDeath = DateOnly.Parse(value);
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
