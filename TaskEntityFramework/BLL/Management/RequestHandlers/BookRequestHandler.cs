
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта обработчик запросов (RequestHandler) 
    /// работающего с запросами (Request => BookRequest)
    /// </summary>
    internal class BookRequestHandler : IRequestHandler<Book, BookUserDto>
    {
        // Данное свойство отвечает за объект взаимодействия с БД.
        private BookRequest _bookRequest;

        public BookRequestHandler()
        {
            _bookRequest = new BookRequest();
        }

        // Данный метод проверяет на пустоту получаемый обьект (Book) по индентификатору.
        public List<Book> Find(int whereValue)
        {
            var book = _bookRequest.Find(whereValue);

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        // Данный метод предначзначен для проверки строковых (string) значений, где столбец по 
        // по которому происходит поиск = nameColumn, а значение требуемое найти = whereValue.
        public List<Book> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (Check(nameColumn) == 0)
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();
            if (nameColumn == "releasedate")
                if (!DateOnly.TryParse(whereValue, out DateOnly result))
                    throw new ArgumentException();

            return _bookRequest.Find(whereValue, nameColumn);
        }

        // Данный метод предназначен для проверки строковых (string) значений для сложных запросов,
        // где command - это целочисленное значение (int) отвечающее за выполняемую команду в запросе,
        // значение первого условия = whereValueFirst , значение второго условия = whereValueSecond ,
        // значение третьего условия = whereValueTree, все они при отсутвии передаваемых значений могут 
        // быть пустыми (null).
        public List<Book> FindTask(
            int command, 
            string whereValueFirst = null, 
            string whereValueSecond = null, 
            string whereValueTree = null)
        {
            if (String.IsNullOrEmpty(whereValueFirst))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(whereValueSecond))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(whereValueTree))
                throw new ArgumentNullException();

            switch (command)
            {
                case 1:
                    if (!DateOnly.TryParse(whereValueSecond, out DateOnly dateResult))
                        throw new ArgumentException();
                    if (!DateOnly.TryParse(whereValueTree, out dateResult))
                        throw new ArgumentException();

                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 2:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 3:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 4:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 5:
                    if (!int.TryParse(whereValueSecond, out int intResult))
                        throw new ArgumentException();

                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 6:
                    if (!int.TryParse(whereValueFirst, out intResult))
                        throw new ArgumentException();

                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 7:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 8:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                case 9:
                    return _bookRequest.TaskFind(command, whereValueFirst, whereValueSecond, whereValueTree);
                default:
                    throw new ArgumentException();
            }

            
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public Book FindFirst()
        {
            var book = _bookRequest.FindFirst();

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту.
        public List<BookUserDto> Join()
        {
            var bookJoinUser = _bookRequest.Join();

            if (bookJoinUser is null)
                throw new NotAssociationException();

            return bookJoinUser;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту.
        public List<BookDescriptionBookDto> Join(string joinTable)
        {
            var bookJoinDescriptionBook = _bookRequest.Join(joinTable);

            if (bookJoinDescriptionBook is null)
                throw new NotAssociationException();

            return bookJoinDescriptionBook;
        }

        // Данный метод предназначен для проврки получаемиого целочисленого (int) значения.
        public int Sum()
        {
            return _bookRequest.Sum();
        }

        // Данный вспомогательный метод предназначен для более удобной и компактной проверки
        // строкового (string) значения nameColumn на соответвтие существующим столбцам в классе
        // Book включая (Join) обьединения.
        public int Check(string nameColumn)
        {
            var listNameColumn = new List<string> {
                "name",
                "releasedate",
                "userid",
                "username",
                "useremail",
                "descriptionid",
                "description",
                "genre",
                "authorid",
                "authorname",
                "authoryearbirth",
                "authoryeardeath"
            };

            foreach (var item in listNameColumn)
            {
                if (nameColumn == item)
                    return 1;
            }

            return 0;
        }
    }
}
