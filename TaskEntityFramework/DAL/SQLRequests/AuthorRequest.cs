
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal class AuthorRequest : Requests<Author, Author>
    {
        public override List<Author> Find(int whereValue)
        {
            using (_db = new MyAppContext())
                return _db.Author.Where(u => u.Id == whereValue).ToList();

        }

        public override List<Author> Find(string whereValue, string nameColumn)
        {
            using (_db = new MyAppContext())
                switch (nameColumn)
                {
                    case "Name":
                        return _db.Author.Where(u => u.Name == whereValue).ToList();
                    case "YearBirth":
                        return _db.Author.Where(u => u.YearBirth == DateTime.Parse(whereValue)).ToList();
                    case "YearDeath":
                        return _db.Author.Where(u => u.YearDeath == DateTime.Parse(whereValue)).ToList();
                    default:
                        return null;
                }
        }

        public override Author FindFirst()
        {
            using (_db = new MyAppContext())
                return _db.Author.First();
        }

        public override List<Author> Join()
        {
            using (_db = new MyAppContext())
                return null;
        }

        public override int Sum()
        {
            using (_db = new MyAppContext())
                return _db.Author.Sum(u => u.Id);
        }
    }
}
