
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта обработчик запросов (RequestHandler) 
    /// работающего с запросами (Request => UserRequest)
    /// </summary>
    internal class UserRequestHandler : IRequestHandler<User, User>
    {
        // Данное свойство отвечает за объект взаимодействия с БД.
        private UserRequest _userRequest;

        public UserRequestHandler() 
        {
            _userRequest = new UserRequest();
        }

        // Данный метод проверяет на пустоту получаемый обьект (User) по индентификатору.
        public List<User> Find(int whereValue)
        {
            var user = _userRequest.Find(whereValue);

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

        // Данный метод предначзначен для проверки строковых (string) значений, где столбец по 
        // по которому происходит поиск = nameColumn, а значение требуемое найти = whereValue.
        public List<User> Find(string whereValue, string nameColumn)
        {
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != "Name" && nameColumn != "Email")
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(whereValue))
                throw new ArgumentNullException();

            var user = _userRequest.Find(whereValue, nameColumn);

            if (user.Count == 0)
                throw new UserNotFoundException();

            return user;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту. 
        public User FindFirst()
        {
            var user = _userRequest.FindFirst();

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

        // Данный метод предназначен для проверки строковых (string) значений для сложных запросов,
        // где command - это целочисленное значение (int) отвечающее за выполняемую команду в запросе,
        // значение первого условия = whereValueFirst , значение второго условия = whereValueSecond ,
        // значение третьего условия = whereValueTree, все они при отсутвии передаваемых значений могут 
        // быть пустыми (null).
        public List<User> FindTask(
            int command, 
            string whereValueFirst = null, 
            string whereValueSecond = null, 
            string whereValueTree = null)
        {
            return null;
        }

        // Данный метод предназначен для проверки получаемого обьекта на пустоту.
        public List<User> Join()
        {
            var userJoinNull = _userRequest.Join();

            if (userJoinNull is null)
                throw new NotAssociationException();

            return userJoinNull;
        }

        // Данный метод предназначен для проврки получаемиого целочисленого (int) значения.
        public int Sum()
        {
            return _userRequest.Sum();
        }
    }
}
