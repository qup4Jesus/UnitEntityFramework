
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class BookFactory : IEntityFactory<Book>
    {
        public Book CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 2)
                throw new ArgumentNullException();
            if (!DateTime.TryParse(input[1], out DateTime result))
                throw new ArgumentNullException();

            DateTime date = DateTime.Parse(input[1]);

            return new Book { Name = input[0], ReleaseDate = date };
        }
    }
}
