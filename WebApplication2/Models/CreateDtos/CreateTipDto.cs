using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateTipDto
    {
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int LeagueId { get; set; }
        public int Tip_score { get; set; }
        public int Goal_count { get; set; }
        public int Tip_goal_home { get; set; }
        public int Tip_goal_away { get; set; }
        public int FootballerId { get; set; }
        
    }
}
