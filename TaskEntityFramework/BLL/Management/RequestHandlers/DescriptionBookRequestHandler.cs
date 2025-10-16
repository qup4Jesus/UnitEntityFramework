
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal class DescriptionBookRequestHandler : IRequestHandler<DescriptionBook, DescriptionBookAuthorDto>
    {
        private DescriptionBookRequest _descriptionBookRequest;

        public DescriptionBookRequestHandler()
        {
            _descriptionBookRequest = new DescriptionBookRequest();
        }

        public List<DescriptionBook> Find(int whereValue)
        {
            var descriptionBook = _descriptionBookRequest.Find(whereValue);

            if (descriptionBook is null)
                throw new DescriptionBookNotFoundException();

            return descriptionBook;
        }

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

        public DescriptionBook FindFirst()
        {
            var descriptionBook = _descriptionBookRequest.FindFirst();

            if (descriptionBook is null)
                throw new DescriptionBookNotFoundException();

            return descriptionBook;
        }

        public List<DescriptionBook> FindTask(int command, string whereValueFirst = null, string whereValueSecond = null, string whereValueTree = null)
        {
            return null;
        }

        public List<DescriptionBookAuthorDto> Join()
        {
            var descriptionBookJoinAuthor = _descriptionBookRequest.Join();

            if (descriptionBookJoinAuthor is null)
                throw new NotAssociationException();

            return descriptionBookJoinAuthor;
        }

        public int Sum()
        {
            return _descriptionBookRequest.Sum();
        }
    }
}
