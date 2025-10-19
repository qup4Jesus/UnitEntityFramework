
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта обработчик запросов (RequestHandler) 
    /// работающего с запросами (Request => DescriprionBookRequest)
    /// </summary>
    internal class AuthorRequestHandler : IRequestHandler<Author, Author>
    {
        // Данное свойство отвечает за объект взаимодействия с БД.
        private AuthorRequest _authorRequest;

        public AuthorRequestHandler()
        {
            _authorRequest = new AuthorRequest();
        }

        // Данный метод проверяет на пустоту получаемый обьект (Author) по индентификатору.
        public List<Author> Find(int whereValue)
        {
            var authorRequest = _authorRequest.Find(whereValue);

            if (authorRequest is null)
                throw new AuthorNotFoundException();

            return authorRequest;
        }

        // Данный метод предначзначен для проверки строковых (string) значений, где столбец по 
        // по которому происходит поиск = nameColumn, а значение требуемое найти = whereValue.
        public List<Author> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != "Name" &&
                nameColumn != "YearBirth" &&
                nameColumn != "YearDeath")
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();
            if (!DateOnly.TryParse(whereValue, out DateOnly result))
                throw new ArgumentException();

            return _authorRequest.Find(whereValue, nameColumn);
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public Author FindFirst()
        {
            var authorRequest = _authorRequest.FindFirst();

            if (authorRequest is null)
                throw new AuthorNotFoundException();

            return authorRequest;
        }

        // Данный метод предназначен для проверки строковых (string) значений для сложных запросов,
        // где command - это целочисленное значение (int) отвечающее за выполняемую команду в запросе,
        // значение первого условия = whereValueFirst , значение второго условия = whereValueSecond ,
        // значение третьего условия = whereValueTree, все они при отсутвии передаваемых значений могут 
        // быть пустыми (null).
        public List<Author> FindTask(int command, string whereValueFirst = null, string whereValueSecond = null, string whereValueTree = null)
        {
            return null;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту.
        public List<Author> Join()
        {
            var authorRequest = _authorRequest.Join();

            if (authorRequest is null)
                throw new NotAssociationException();

            return authorRequest;
        }

        // Данный метод предназначен для проврки получаемиого целочисленого (int) значения.
        public int Sum()
        {
            return _authorRequest.Sum();
        }
    }
}
