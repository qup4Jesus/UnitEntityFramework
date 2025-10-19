
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта обработчик запросов (RequestHandler) 
    /// работающего с запросами (Request => DescriprionBookRequest)
    /// </summary>
    internal class DescriptionBookRequestHandler : IRequestHandler<DescriptionBook, DescriptionBookAuthorDto>
    {
        // Данное свойство отвечает за объект взаимодействия с БД.
        private DescriptionBookRequest _descriptionBookRequest;

        public DescriptionBookRequestHandler()
        {
            _descriptionBookRequest = new DescriptionBookRequest();
        }

        // Данный метод проверяет на пустоту получаемый обьект (DescriptionBook) по индентификатору.
        public List<DescriptionBook> Find(int whereValue)
        {
            var descriptionBook = _descriptionBookRequest.Find(whereValue);

            if (descriptionBook is null)
                throw new DescriptionBookNotFoundException();

            return descriptionBook;
        }

        // Данный метод предначзначен для проверки строковых (string) значений, где столбец по 
        // по которому происходит поиск = nameColumn, а значение требуемое найти = whereValue.
        public List<DescriptionBook> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != "Description" && nameColumn != "Genre")
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();

            return _descriptionBookRequest.Find(whereValue, nameColumn);
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public DescriptionBook FindFirst()
        {
            var descriptionBook = _descriptionBookRequest.FindFirst();

            if (descriptionBook is null)
                throw new DescriptionBookNotFoundException();

            return descriptionBook;
        }

        // Данный метод предназначен для проверки строковых (string) значений для сложных запросов,
        // где command - это целочисленное значение (int) отвечающее за выполняемую команду в запросе,
        // значение первого условия = whereValueFirst , значение второго условия = whereValueSecond ,
        // значение третьего условия = whereValueTree, все они при отсутвии передаваемых значений могут 
        // быть пустыми (null).
        public List<DescriptionBook> FindTask(
            int command, 
            string whereValueFirst = null, 
            string whereValueSecond = null, 
            string whereValueTree = null)
        {
            return null;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту.
        public List<DescriptionBookAuthorDto> Join()
        {
            var descriptionBookJoinAuthor = _descriptionBookRequest.Join();

            if (descriptionBookJoinAuthor is null)
                throw new NotAssociationException();

            return descriptionBookJoinAuthor;
        }

        // Данный метод предназначен для проврки получаемиого целочисленого (int) значения.
        public int Sum()
        {
            return _descriptionBookRequest.Sum();
        }
    }
}
