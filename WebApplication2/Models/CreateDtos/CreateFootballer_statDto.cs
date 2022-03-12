using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateFootballer_statDto
    {
        public int FootballerId { get; set; }
        public int MatchId { get; set; }
        public int If_goal { get; set; }
        public int If_cleansheet { get; set; }
    }
}
