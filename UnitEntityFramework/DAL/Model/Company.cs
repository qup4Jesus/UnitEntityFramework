
namespace UnitEntityFramework.DAL.Model
{
    public class Company : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
