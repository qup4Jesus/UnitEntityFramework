
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class UserFactory : IEntityFactory<User>
    {
        public User CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 2)
                throw new ArgumentNullException();

            return new User { Name = input[0], Email = input[1] };
        }
    }
}
