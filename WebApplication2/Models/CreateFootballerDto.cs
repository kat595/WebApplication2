using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateFootballerDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public virtual Club Club { get; set; }
    }
}
