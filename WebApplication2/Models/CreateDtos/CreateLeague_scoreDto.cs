using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class CreateLeague_scoreDto
    {
        public int UserId { get; set; }
        public int LeagueId { get; set; }
        public double Score { get; set; }
    }
}
