
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class ManagerAuthor : IManager<Author>
    {
        private AuthorRepository _manager;

        public ManagerAuthor(AuthorRepository manager)
        {
            _manager = manager;
        }

        public void Add(List<Author> listElements)
        {
            foreach (var author in listElements)
            {
                if (String.IsNullOrEmpty(author.Name))
                    throw new ArgumentNullException();
                if (!(author.YearBirth is DateTime))
                    throw new ArgumentNullException();
                if (!(author.YearDeath is DateTime))
                    throw new ArgumentNullException();
            }

            _manager.Add(listElements);
        }

        public void Delete(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }

        public List<Author> ReadAll()
        {
            var author = _manager.ReadAll();

            if (author.Count == 0)
                throw new ArgumentNullException();

            return author;
        }

        public Author ReadOne(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new ArgumentNullException();

            return author;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(author.Name))
                throw new ArgumentNullException();
            if (nameColumn != nameof(author.YearBirth))
                throw new ArgumentNullException();
            if (nameColumn != nameof(author.YearDeath))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }
    }
}

