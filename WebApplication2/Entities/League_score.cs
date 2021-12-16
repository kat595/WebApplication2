namespace WebApplication2.Entities
{
    public class League_score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public double Score { get; set; }

    }
}
