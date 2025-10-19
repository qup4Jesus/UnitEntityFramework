
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    /// <summary>
    /// Данный абстрактный класс предназначен для непосредствнной работы с БД, 
    /// реализующий основные методы работы с ней (CRUD)
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table 
    /// для унниверсальной работы </typeparam>
    internal abstract class AbstractRepository<TEntity> where TEntity : Table
    {
        // Сущность БД
        protected private MyAppContext _db;

        // Create: Метод для добавления элементов в базу данных 
        public abstract void Add(List<TEntity> newElements);

        // Read: Метод для просмотра всех элементов в базе данных
        public abstract List<TEntity> ReadAll();

        // Read: Метод для просмотра элемента по его id в базе данных
        public abstract TEntity ReadOne(int id);

        // Update: Метод для обновления элементов по Id
        public abstract void Update(int id, string nameColumn, string value);

        // Delete: Метод для удаления элементов по Id
        public abstract void Delete(int id);
    }
}
