
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    /// <summary>
    /// Данный абстрактный класс предназначен для выполнения запрососв к БД.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table 
    /// для унниверсальной работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DataTransferObject 
    /// для универсальной работы </typeparam>
    internal abstract class Requests<TEntity, TDto> 
        where TEntity : Table
        where TDto : Table
    {
        // Присваивает каждому наследнику сущность БД.
        protected private MyAppContext _db;

        // Данный метод отвечает за нахождение записей по условию с целочисленным значением.
        public abstract List<TEntity> Find(int whereValue);

        // Данный метод отвечает за нахождение записей по условию со строковыми значениями,
        // где whereValue - это значение которое требется найти;
        // nameColumn - это значение столбца по которому требуется произввести поиск.
        public abstract List<TEntity> Find(string whereValue, string nameColumn);

        // Данный метод предназначен для нахождения первого элемента в таблице
        public abstract TEntity FindFirst();

        // Данный метод позваляет произвести присоединение таблиц.
        public abstract List<TDto> Join();

        // Данный метод предназначен для нахождения суммы значений передоваемого столбца.
        public abstract int Sum();
    }
}
