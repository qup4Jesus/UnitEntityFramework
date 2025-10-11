
using Microsoft.EntityFrameworkCore.Internal;
using System.Net.Http.Headers;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    internal class DescriptionBookRepository : AbstractRepository<DescriptionBook>
    {
        public DescriptionBookRepository() : base() { }

        public override void Add(List<DescriptionBook> newElements)
        {
            using (_db)
            {
                _db.AddRange(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db)
            {
                var descriptionBook = _db.DescriptionBooks.Find(id);

                _db.DescriptionBooks.Remove(descriptionBook);

                _db.SaveChanges();
            }
        }

        public override List<DescriptionBook> ReadAll()
        {
            using (_db)
            {
                return _db.DescriptionBooks.ToList();
            }
        }

        public override DescriptionBook ReadOne(int id)
        {
            using (_db)
            {
                return _db.DescriptionBooks.Find(id);
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db)
            {
                var descriptionBook = _db.DescriptionBooks.Find(id);

                switch (nameColumn)
                {
                    case nameof(descriptionBook.Description):
                        descriptionBook.Description = value;
                        break;
                    case nameof(descriptionBook.Genre):
                        descriptionBook.Genre = value;
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
