
using System.Net;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal class BookRequest : Requests<Book, BookUserDto>
    {
        public override List<Book> Find(int whereValue)
        {
            using (_db)
            {
                return _db.Books.Where(u => u.Id == whereValue).ToList();
            }
        }

        public override List<Book> Find(string whereValue, string nameColumn)
        {
            using (_db)
            {
                switch (nameColumn)
                {
                    case "Name":
                        return _db.Books.Where(u => u.Name == whereValue).ToList();
                    case "ReleaseDate":
                        return _db.Books.Where(u => u.ReleaseDate == DateTime.Parse(whereValue)).ToList();
                    default:
                        return null;
                }
            }
        }

        public override Book FindFirst()
        {
            using (_db)
            {
                return _db.Books.First();
            }
        }

        public override List<BookUserDto> Join()
        {
            using (_db)
            {
                return _db.Books
                    .Join(_db.Users,
                        b => b.UserId,
                        u => u.Id,
                        (b, u) => new BookUserDto { 
                            BookId = b.Id,
                            BookName = b.Name,
                            ReleaseDate = b.ReleaseDate,
                            UserId = u.Id,
                            UserName = u.Name,
                            Email = u.Email,
                            DescriptionBookId = b.DescriptionBookId
                        }).ToList();

            }
        }

        new public List<BookDescriptionBookDto> Join(string joinTable)
        {
            using (_db)
            {
                return _db.Books
                    .Join(_db.DescriptionBooks,
                        b => b.DescriptionBookId,
                        db => db.Id,
                        (b, db) => new BookDescriptionBookDto
                        {
                            BookId = b.Id,
                            BookName = b.Name,
                            ReleaseDate = b.ReleaseDate,
                            DescriptionBookId = db.Id,
                            Description = db.Description,
                            Genre = db.Genre,
                            UserId = b.UserId,
                            AuthorId = db.AuthorId
                        }).ToList();

            }
        }

        public override int Sum()
        {
            using (_db)
            {
                return _db.Books.Sum(u => u.Id);
            }
        }
    }
}
