
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal class DescriptionBookRequest : Requests<DescriptionBook, DescriptionBookAuthorDto>
    {
        public override List<DescriptionBook> Find(int whereValue)
        {
            using (_db)
            {
                return _db.DescriptionBooks.Where(u => u.Id == whereValue).ToList();
            }
        }

        public override List<DescriptionBook> Find(string whereValue, string nameColumn)
        {
            using (_db)
            {
                switch (nameColumn)
                {
                    case "Description":
                        return _db.DescriptionBooks.Where(u => u.Description == whereValue).ToList();
                    case "Genre":
                        return _db.DescriptionBooks.Where(u => u.Genre == whereValue).ToList();
                    default:
                        return null;
                }
            }
        }

        public override DescriptionBook FindFirst()
        {
            using (_db)
            {
                return _db.DescriptionBooks.First();
            }
        }

        public override List<DescriptionBookAuthorDto> Join()
        {
            using (_db)
            {
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
        }

        public override int Sum()
        {
            using (_db)
            {
                return _db.DescriptionBooks.Sum(u => u.Id);
            }
        }
    }
}
