
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    /// <summary>
    /// Данный класс
    /// </summary>
    internal class AuthorRequest : Requests<Author, Author>
    {
        public override List<Author> Find(int whereValue)
        {
            // Выполняем запрос по поиску авторов у которых Id = whereValue.
            using (_db = new MyAppContext())
                return _db.Author.Where(u => u.Id == whereValue).ToList();

        }

        public override List<Author> Find(string whereValue, string nameColumn)
        {
            // Выполняем запрос по поиску авторов, где столбец равен nameColumn, 
            // а искомое значение равно whereValue.
            using (_db = new MyAppContext())
                switch (nameColumn)
                {
                    // По столбцу "Name".
                    case "Name":
                        return _db.Author.Where(u => u.Name == whereValue).ToList();

                    // По столбцу "YearBirth".
                    case "YearBirth":
                        return _db.Author.Where(u => u.YearBirth == DateOnly.Parse(whereValue)).ToList();

                    // По столбцу "YearDeath".
                    case "YearDeath":
                        return _db.Author.Where(u => u.YearDeath == DateOnly.Parse(whereValue)).ToList();

                    // Иначе null.
                    default:
                        return null;
                }
        }

        public override Author FindFirst()
        {
            // Выполняем запрос на получение автора находящегося первым в таблице.
            using (_db = new MyAppContext())
                return _db.Author.First();
        }

        public override List<Author> Join()
        {
            // Выполняем запрос по присоединение. Которого нет, поэтому и возвращаем null.
            using (_db = new MyAppContext())
                return null;
        }

        public override int Sum()
        {
            // Выполняем запрос на получение суммы индентификаторов.
            using (_db = new MyAppContext())
                return _db.Author.Sum(u => u.Id);
        }
    }
}
