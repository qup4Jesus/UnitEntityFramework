
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class AuthorManager : IManager<Author, Author>
    {
        private AuthorRepository _manager;
        private AuthorFactory _factory;
        public IRequestHandler<Author, Author> RequestHandlers { get; set; }
        public AuthorManager()
        {
            _manager = new AuthorRepository();
            _factory = new AuthorFactory();
            RequestHandlers = new AuthorRequestHandler();
        }

        public void Add(List<Author> listElements)
        {
            foreach (var author in listElements)
            {
                if (String.IsNullOrEmpty(author.Name))
                    throw new ArgumentNullException();
                if (!(author.YearBirth is DateTime))
                    throw new ArgumentException();
                if (!(author.YearDeath is DateTime))
                    throw new ArgumentException();
            }

            _manager.Add(listElements);
        }

        public void Delete(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();

            _manager.Delete(id);
        }

        public List<Author> ReadAll()
        {
            var author = _manager.ReadAll();

            //if (author is null)
            //    throw new AuthorNotFoundException();

            return author;
        }

        public Author ReadOne(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();

            return author;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(author.Name) && 
                nameColumn != nameof(author.YearBirth) && 
                nameColumn != nameof(author.YearDeath))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }

        public IEntityFactory<Author> GetFactory()
        {
            return _factory;
        }
    }
}

