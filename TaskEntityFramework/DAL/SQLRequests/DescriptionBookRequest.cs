
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;

namespace TaskEntityFramework.DAL.SQLRequests
{
    /// <summary>
    /// Данный класс предназначен для выполнения запрососв к БД (сущность DescriptionBook).
    /// </summary>
    internal class DescriptionBookRequest : Requests<DescriptionBook, DescriptionBookAuthorDto>
    {
        // Выполняем запрос по поиску описания книг у которых Id = whereValue.
        public override List<DescriptionBook> Find(int whereValue)
        {
            return _db.DescriptionBooks.Where(u => u.Id == whereValue).ToList();
        }

        public override List<DescriptionBook> Find(string whereValue, string nameColumn)
        {
            // Выполняем запрос по поиску книг, где столбец равен nameColumn, 
            // а искомое значение равно whereValue.
            switch (nameColumn)
            {
                // По столбцу "Description".
                case "description":
                    return _db.DescriptionBooks.Where(u => u.Description == whereValue).ToList();
                // По столбцу "Genre".
                case "genre":
                    return _db.DescriptionBooks.Where(u => u.Genre == whereValue).ToList();
                // Иначе вернется null.
                default:
                    return null;
            }
        }

        public override DescriptionBook FindFirst()
        {
            // Выполняем запрос на получение описания книги находящейся первой в таблице.
            return _db.DescriptionBooks.First();
        }

        public override List<DescriptionBookAuthorDto> Join()
        {
            // Выполняем запрос на получение списка обьединения (Join) таблиц Описание книги
            // (DescriptonBook) и Пользователь (Author), возвращаем все взаимосвязанные значения.
            return _db.DescriptionBooks
                .Join(_db.Author,
                    db => db.AuthorId,
                    a => a.Id,
                    (db, a) => new DescriptionBookAuthorDto
                    {
                        DescriptionBookId = db.Id,
                        Description = db.Description,
                        Genre = db.Genre,
                        AuthorId = a.Id,
                        Name = a.Name,
                        YearBirth = a.YearBirth,
                        YearDeath = a.YearDeath
                    }).ToList();
        }

        public override int Sum()
        {
            // Выполняем запрос на получение суммы индентификаторов.
            return _db.DescriptionBooks.Sum(u => u.Id);
        }
    }
}
