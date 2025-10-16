
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class BookFactory : IEntityFactory<Book>
    {
        public Book CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 4)
                throw new ArgumentNullException();
            if (!DateOnly.TryParse(input[1], out DateOnly result))
                throw new ArgumentNullException();
            if (!int.TryParse(input[2], out int result1))
                throw new ArgumentException();
            if (!int.TryParse(input[3], out result1))
                throw new ArgumentException();

            DateOnly date = DateOnly.Parse(input[1]);
            int idUser = int.Parse(input[2]);
            int idDescription = int.Parse(input[3]);

            return new Book { Name = input[0], ReleaseDate = date, UserId = idUser, DescriptionBookId = idDescription };
        }
    }
}
