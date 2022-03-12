using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateOddDto
    {
        public int MatchId { get; set; }
        public double Odd_home { get; set; }
        public double Odd_away { get; set; }
        public double Odd_draw { get; set; }
        public double Odd_under2 { get; set; }
        public double Odd_over2 { get; set; }
        public double Odd_goal_forward { get; set; }
        public double Odd_goal_midfielder { get; set; }
        public double Odd_goal_defender { get; set; }
        public double Odd_cleansheet { get; set; }
    }
}
