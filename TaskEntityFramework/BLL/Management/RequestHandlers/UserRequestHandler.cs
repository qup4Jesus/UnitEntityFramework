
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.SQLRequests;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal class UserRequestHandler : IRequestHandler<User, User>
    {
        private UserRequest _userRequest;

        public UserRequestHandler() 
        {
            _userRequest = new UserRequest();
        }

        public List<User> Find(int whereValue)
        {
            var user = _userRequest.Find(whereValue);

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

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

        public User FindFirst()
        {
            var user = _userRequest.FindFirst();

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

        public List<User> Join()
        {
            var userJoinNull = _userRequest.Join();

            if (userJoinNull is null)
                throw new NotAssociationException();

            return userJoinNull;
        }

        public int Sum()
        {
            return _userRequest.Sum();
        }
    }
}
