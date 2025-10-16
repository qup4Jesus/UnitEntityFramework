
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal class BookRequest : Requests<Book, BookUserDto>
    {
        public override List<Book> Find(int whereValue)
        {
            using (_db = new MyAppContext())
                return _db.Books.Where(u => u.Id == whereValue).ToList();
        }

        public override List<Book> Find(string whereValue, string nameColumn)
        {
            using (_db = new MyAppContext())
                switch (nameColumn.ToLower())
                {
                    case "name":
                        return _db.Books.Where(b => b.Name == whereValue).ToList();
                    case "releasedate":
                        return _db.Books.Where(b => b.ReleaseDate == DateOnly.Parse(whereValue)).ToList();
                    case "userid":
                        return _db.Books.Where(b => b.UserId == int.Parse(whereValue)).ToList();
                    case "username":
                        return _db.Books.Where(b => b.User.Name == whereValue).ToList();
                    case "useremail":
                        return _db.Books.Where(b => b.User.Email == whereValue).ToList();
                    case "descriptionid":
                        return _db.Books.Where(b => b.DescriptionBook.Id == int.Parse(whereValue)).ToList();
                    case "description":
                        return _db.Books.Where(b => b.DescriptionBook.Description == whereValue).ToList();
                    case "genre":
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValue).ToList();
                    case "authorid":
                        return _db.Books.Where(b => b.DescriptionBook.AuthorId == int.Parse(whereValue)).ToList();
                    case "authorname":
                        return _db.Books.Where(b => b.DescriptionBook.Author.Name == whereValue).ToList();
                    case "authoryearbirth":
                        return _db.Books.Where(b => b.DescriptionBook.Author.YearBirth == DateOnly.Parse(whereValue)).ToList();
                    case "authoryeardeath":
                        return _db.Books.Where(b => b.DescriptionBook.Author.YearDeath == DateOnly.Parse(whereValue)).ToList();
                    default:
                        return null;
                }
        }

        public List<Book> TaskFind(int command, string whereValueFirst, string whereValueSecond, string whereValueTree)
        {
            using (_db = new MyAppContext())
                switch (command)
                {
                    case 1:
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValueFirst && b.ReleaseDate >= DateOnly.Parse(whereValueSecond) && b.ReleaseDate <= DateOnly.Parse(whereValueTree)).ToList();
                    case 2:
                        return _db.Books.Where(b => b.DescriptionBook.Author.Name == whereValueFirst).ToList();
                    case 3:
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValueFirst).ToList();
                    case 4:
                        return _db.Books.Where(b => b.Name == whereValueFirst && b.DescriptionBook.Author.Name == whereValueSecond).ToList();
                    case 5:
                        return _db.Books.Where(b => b.Name == whereValueFirst && b.UserId == int.Parse(whereValueSecond)).ToList();
                    case 6:
                        return _db.Books.Where(b => b.UserId == int.Parse(whereValueFirst)).ToList();
                    case 7:
                        return new List<Book> { _db.Books.OrderByDescending(b => b.ReleaseDate).FirstOrDefault() };
                    case 8:
                        return _db.Books.OrderBy(b => b.Name).ToList();
                    case 9:
                        return _db.Books.OrderByDescending(b => b.ReleaseDate.Year).ToList();
                    default:
                        return null;
                }
        }

        public override Book FindFirst()
        {
            using (_db = new MyAppContext())
                return _db.Books.First();
        }

        public override List<BookUserDto> Join()
        {
            using (_db = new MyAppContext())
                return _db.Books
                .Join(_db.Users,
                    b => b.UserId,
                    u => u.Id,
                    (b, u) => new BookUserDto
                    {
                        BookId = b.Id,
                        BookName = b.Name,
                        ReleaseDate = b.ReleaseDate,
                        UserId = u.Id,
                        UserName = u.Name,
                        Email = u.Email,
                        DescriptionBookId = b.DescriptionBookId
                    }).ToList();
        }

        new public List<BookDescriptionBookDto> Join(string joinTable)
        {
            using (_db = new MyAppContext())
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

        public override int Sum()
        {
            using (_db = new MyAppContext())
                return _db.Books.Sum(u => u.Id);
        }
    }
}
