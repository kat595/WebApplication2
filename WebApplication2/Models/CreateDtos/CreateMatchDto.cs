using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateMatchDto
    {
        public int Gameweek { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int Result { get; set; }
        public int Goal_home { get; set; }
        public int Goal_away { get; set; }
    }
}
