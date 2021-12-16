namespace WebApplication2.Entities
{
    public class Footballer_stat
    {
        public int Id { get; set; }
        public int FootballerId { get; set;}
        public virtual Footballer Footballer { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public int If_goal { get; set; }
        public int If_cleansheet { get; set; }

    }
}
