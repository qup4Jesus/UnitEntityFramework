
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class DescriptionBookFactory : IEntityFactory<DescriptionBook>
    {
        public DescriptionBook CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 3)
                throw new ArgumentNullException();
            if (!int.TryParse(input[2], out int result1))
                throw new ArgumentException();

            int idAuthor = int.Parse(input[2]);

            return new DescriptionBook { Description = input[0], Genre = input[1], AuthorId = idAuthor };
        }
    }
}
