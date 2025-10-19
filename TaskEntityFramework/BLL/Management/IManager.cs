
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management
{
    /// <summary>
    /// Данный контракт предначначен для создания классов (Manager), которые проверяют
    /// данные на соответствие требованиям для передачи в последующей корректной обработки
    /// в Repository.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table для универсальной
    /// работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DateTransferObject для 
    /// универсальной работы </typeparam>
    internal interface IManager<TEntity, TDto> 
        where TEntity : Table
        where TDto : Table
    {
        // Данное свойство отвечает за обьекты фабрика-сборщик (EntityFactory)
        public IEntityFactory<TEntity> _factory { get; set; }

        // Данное свойство отвечает за обьекты обработчика запросов (RequestHandlers)
        public IRequestHandler<TEntity, TDto> RequestHandlers { get; set; }

        // Данный метод принимает коллекцию элементов, которая определяется менеджером (Manager)
        // для проверки данных на соответвие требованиям для корректной обработки в Repository.
        // В ином случае информативная ошибка , кроме не предвиденных исключений.
        public void Add(List<TEntity> listElements);

        // Данный метод возвращает не пустую коллекцию элементов из хранилища. В ином случае
        // информативная ошибка , кроме не предвиденных исключений.
        public List<TEntity> ReadAll();

        // Данный метод проверяет поступающие данные на корректность и возвращает не пустую запись
        // по её идентификатору из хранилилища. В ином случае информативная ошибка , кроме не
        // предвиденных исключений.
        public TEntity ReadOne(int id);

        // Данный метод проверяет поступающие данные на корректность и обновляет запись внутри 
        // хранилища заменяя запись под индентификатором = id , столбец = nameColumn на значение
        // = value. В ином случае информативная ошибка , кроме не предвиденных исключений.
        public void Update(int id, string nameColumn, string value);

        // Данный метод проверяет поступающие данный на корректность и удаляет запись под 
        // индентификатором = id. В ином случае информативная ошибка , кроме не предвиденных
        // исключений.
        public void Delete(int id);

        // Данный метод предназначен для получения (фабрика-сборщик) конктреного обьекта 
        // соответствующего передаваемым параметрам менеджера.
        public IEntityFactory<TEntity> GetFactory() => _factory;
    }
}
