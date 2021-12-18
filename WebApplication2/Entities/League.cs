namespace WebApplication2.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string League_name { get; set; }
        public DateTime Creation_date { get; set; }
        public List<User> Users { get; set; }

        public IList<League_founder> LeagueFounders { get; set; }

        public IList<League_score> LeagueScores { get; set;}
    }
}
