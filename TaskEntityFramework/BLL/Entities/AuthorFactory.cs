
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class AuthorFactory : IEntityFactory<Author>
    {
        public Author CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 3)
                throw new ArgumentNullException();
            if (!DateTime.TryParse(input[1], out DateTime result))
                throw new ArgumentNullException();
            if (!DateTime.TryParse(input[2], out result))
                throw new ArgumentNullException();

            DateTime dateBrith = DateTime.Parse(input[1]);
            DateTime dateDeath = DateTime.Parse(input[2]);

            return new Author { Name = input[0], YearBirth = dateBrith, YearDeath = dateDeath };
        }
    }
}
