
namespace TaskEntityFramework.DAL.Repositories
{
    internal abstract class AbstractRepository<T> where T : class
    {
        // Сущность БД
        protected private MyAppContext _db;

        // Create: Метод для добавления элементов в базу данных 
        public abstract void Add(List<T> newElements);

        // Read: Метод для просмотра всех элементов в базе данных
        public abstract List<T> ReadAll();

        // Read: Метод для просмотра элемента по его id в базе данных
        public abstract T ReadOne(int id);

        // Update: Метод для обновления элементов по Id
        public abstract void Update(int id, string nameColumn, string value);

        // Delete: Метод для удаления элементов по Id
        public abstract void Delete(int id);
    }
}
