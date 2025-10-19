
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    /// <summary>
    /// Данный контракт предназначен для создания классов (RequestHandler), которые проверяют 
    /// поступающие данные на корректность и соответствие требованиям. При выполнении всех 
    /// требований вызывается запрос (Request) в которой передаются проверенные данные.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table для универсальной
    /// работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DateTransferObject для универсальной
    /// работы </typeparam>
    internal interface IRequestHandler<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        // Данный метод предназначен для проверки данных целочисленого (int) значения.
        public List<TEntity> Find(int whereValue);

        // Данный метод предначзначен для проверки строковых (string) значений, где столбец по 
        // по которому происходит поиск = nameColumn, а значение требуемое найти = whereValue.
        public List<TEntity> Find(string whereValue, string nameColumn);

        // Данный метод преедназначен для проверки строковых (string) значений для сложных запросов,
        // где command - это целочисленное значение (int) отвечающее за выполняемую команду в запросе,
        // значение первого условия = whereValueFirst , значение второго условия = whereValueSecond ,
        // значение третьего условия = whereValueTree, все они при отсутвии передаваемых значений могут 
        // быть пустыми (null).
        public List<TEntity> FindTask(
            int command, 
            string whereValueFirst = null, 
            string whereValueSecond = null, 
            string whereValueTree = null);

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public TEntity FindFirst();

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public List<TDto> Join();

        // Данный метод предназначен для проврки получаемиого целочисленого (int) значения.
        public int Sum();
    }
}
