namespace WebApplication2.Entities
{
    public class League_founder
    {
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public int FounderId { get; set; }
        public virtual User Founder { get; set; }
    }
}
