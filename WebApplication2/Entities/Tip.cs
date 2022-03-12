namespace WebApplication2.Entities
{
    public class Tip
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public int Tip_score { get; set; }
        public int Goal_count { get; set; }
        public int Tip_goal_home { get; set; }
        public int Tip_goal_away { get; set; }
        public int FootballerId { get; set; }
        public virtual Footballer Footballer { get; set; }

    }
}
