
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class DescriptionBookManager : IManager<DescriptionBook, DescriptionBookAuthorDto>
    {
        private DescriptionBookRepository _manager;
        private DescriptionBookFactory _factory;
        public DescriptionBookManager()
        {
            _manager = new DescriptionBookRepository();
            _factory = new DescriptionBookFactory();
        }

        public void Add(List<DescriptionBook> listElements)
        {
            foreach (var book in listElements)
            {
                if (String.IsNullOrEmpty(book.Description))
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(book.Genre))
                    throw new ArgumentNullException();
            }

            _manager.Add(listElements);
        }

        public void Delete(int id)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }

        public List<DescriptionBook> ReadAll()
        {
            var books = _manager.ReadAll();

            if (books.Count == 0)
                throw new ArgumentNullException();

            return books;
        }

        public DescriptionBook ReadOne(int id)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new ArgumentNullException();

            return book;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.Description))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.Genre))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }

        public IEntityFactory<DescriptionBook> GetFactory()
        {
            return _factory;
        }
    }
}
