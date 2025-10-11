
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal class DescriptionBookFactory : IEntityFactory<DescriptionBook>
    {
        public DescriptionBook CreateFromUserInput(List<string> input)
        {
            if (input is null)
                throw new ArgumentNullException();
            if (input.Count > 2)
                throw new ArgumentNullException();

            return new DescriptionBook { Description = input[0], Genre = input[1] };
        }
    }
}
