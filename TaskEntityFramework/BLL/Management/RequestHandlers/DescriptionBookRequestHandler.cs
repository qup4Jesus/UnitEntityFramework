
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
            if (nameColumn != "Description")
                throw new ColumnNotFoundException();
            if (nameColumn != "Genre")
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
