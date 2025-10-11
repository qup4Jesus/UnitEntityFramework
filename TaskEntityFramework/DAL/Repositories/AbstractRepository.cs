
namespace TaskEntityFramework.DAL.Repositories
{
    internal abstract class AbstractRepository<T> where T : class
    {
        // Сущность БД
        protected private MyAppContext _db;

        // Конструктор в котором инициализируем подключение к БД
        public AbstractRepository()
        {
            _db = new MyAppContext();
        }

        // Create: Метод для добавления элементов в базу данных 
        public abstract void Add(List<T> newElements);

        // Read: Метод для просмотра элементов в базе данных
        public abstract List<T> ReadAll();

        // Update: Метод для обновления элементов по Id
        public abstract void Update(int id, string nameColumn, string value);

        // Delete: Метод для удаления элементов по Id
        public abstract void Delete(int id);
    }
}
