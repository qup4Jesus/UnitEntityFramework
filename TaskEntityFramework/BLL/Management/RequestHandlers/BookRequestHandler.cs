
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal class BookRequestHandler : IRequestHandler<Book, BookUserDto>
    {
        private BookRequest _bookRequest;

        public BookRequestHandler()
        {
            _bookRequest = new BookRequest();
        }

        public List<Book> Find(int whereValue)
        {
            var book = _bookRequest.Find(whereValue);

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        public List<Book> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != "Name")
                throw new ColumnNotFoundException();
            if (nameColumn != "ReleaseDate")
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();
            if (!DateTime.TryParse(whereValue, out DateTime result))
                throw new ArgumentException();

            return _bookRequest.Find(whereValue, nameColumn);
        }

        public Book FindFirst()
        {
            var book = _bookRequest.FindFirst();

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        public List<BookUserDto> Join()
        {
            var bookJoinUser = _bookRequest.Join();

            if (bookJoinUser is null)
                throw new NotAssociationException();

            return bookJoinUser;
        }

        public List<BookDescriptionBookDto> Join(string joinTable)
        {
            var bookJoinDescriptionBook = _bookRequest.Join(joinTable);

            if (bookJoinDescriptionBook is null)
                throw new NotAssociationException();

            return bookJoinDescriptionBook;
        }

        public int Sum()
        {
            return _bookRequest.Sum();
        }
    }
}
