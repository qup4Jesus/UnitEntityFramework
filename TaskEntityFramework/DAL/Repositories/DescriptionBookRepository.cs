
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    /// <summary>
    /// Данный класс предназначен для работы непосредственно с БД для сущности DescriptionBook
    /// </summary>
    internal class DescriptionBookRepository : AbstractRepository<DescriptionBook>
    {
        public override void Add(List<DescriptionBook> newElements)
        {
            using (_db = new MyAppContext())
            {
                // Добавление одиночного описания, для добавление нескольких
                // описаний используем AddRange(element1, ... ,element54);
                _db.AddRange(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db = new MyAppContext())
            {
                // Удаление конкретного описания по Id
                var descriptionBook = _db.DescriptionBooks.Find(id);

                // Удаление одиночного описания для удаления нескольких
                // описаний используем RemoveRange(element1, ... ,element72);
                _db.DescriptionBooks.Remove(descriptionBook);

                _db.SaveChanges();
            }
        }

        public override List<DescriptionBook> ReadAll()
        {
            using (_db = new MyAppContext())
            {
                // Получение всех существующих описаний в БД
                return _db.DescriptionBooks.ToList();
            }
        }

        public override DescriptionBook ReadOne(int id)
        {
            using (_db = new MyAppContext())
            {
                // Получение конкретного описания по Id
                return _db.DescriptionBooks.Find(id);
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db = new MyAppContext())
            {
                // Изменение описания по его Id
                var descriptionBook = _db.DescriptionBooks.Find(id);

                switch (nameColumn)
                {
                    // Изменение описания 
                    case nameof(descriptionBook.Description):
                        descriptionBook.Description = value;
                        break;
                    // Изменение жанра
                    case nameof(descriptionBook.Genre):
                        descriptionBook.Genre = value;
                        break;
                    default:
                    // При не соответствии Error
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
