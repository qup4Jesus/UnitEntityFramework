
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    internal class AuthorRepository : AbstractRepository<Author>
    {
        public override void Add(List<Author> newElements)
        {
            using (_db = new MyAppContext())
            {
                _db.AddRange(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db = new MyAppContext())
            {
                var author = _db.Author.Find(id);

                _db.Author.Remove(author);

                _db.SaveChanges();
            }
        }

        public override List<Author> ReadAll()
        {
            using (_db = new MyAppContext())
            {
                return _db.Author.ToList();
            }
        }

        public override Author ReadOne(int id)
        {
            using (_db = new MyAppContext())
            {
                return _db.Author.Find(id);
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db = new MyAppContext())
            {
                var author = _db.Author.Find(id);

                switch (nameColumn)
                {
                    case nameof(author.Name):
                        author.Name = value;
                        break;
                    case nameof(author.YearBirth):
                        author.YearBirth = DateOnly.Parse(value);
                        break;
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
