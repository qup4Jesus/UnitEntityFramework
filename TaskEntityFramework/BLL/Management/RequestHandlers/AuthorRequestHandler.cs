
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal class AuthorRequestHandler : IRequestHandler<Author, Author>
    {
        private AuthorRequest _authorRequest;

        public AuthorRequestHandler()
        {
            _authorRequest = new AuthorRequest();
        }

        public List<Author> Find(int whereValue)
        {
            var authorRequest = _authorRequest.Find(whereValue);

            if (authorRequest is null)
                throw new AuthorNotFoundException();

            return authorRequest;
        }

        public List<Author> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != "Name")
                throw new ColumnNotFoundException();
            if (nameColumn != "GeYearBirth")
                throw new ColumnNotFoundException();
            if (nameColumn != "YearDeath")
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();
            if (!DateTime.TryParse(whereValue, out DateTime result))
                throw new ArgumentException();

            return _authorRequest.Find(whereValue, nameColumn);
        }

        public Author FindFirst()
        {
            var authorRequest = _authorRequest.FindFirst();

            if (authorRequest is null)
                throw new AuthorNotFoundException();

            return authorRequest;
        }

        public List<Author> Join()
        {
            var authorRequest = _authorRequest.Join();

            if (authorRequest is null)
                throw new NotAssociationException();

            return authorRequest;
        }

        public int Sum()
        {
            return _authorRequest.Sum();
        }
    }
}
