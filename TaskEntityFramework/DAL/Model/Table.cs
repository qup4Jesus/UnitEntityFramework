
using System.Text.Json.Serialization;

namespace TaskEntityFramework.DAL.Model
{
    internal abstract class Table 
    {
        public string Name;
        public string? Email;
        public DateTime ReleaseDate;
    }
}
