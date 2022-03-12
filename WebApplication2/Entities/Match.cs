namespace WebApplication2.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int Gameweek { get; set; }
        public int HomeId { get; set; }
        public virtual Club Home { get; set; }
        public int AwayId { get; set; }
        public virtual Club Away { get; set; }
        public int Result { get; set; } // 1-zwyciestwo gospodarza, 2-zwyciestwo goscia, 0-remis
        public int Goal_home { get; set; }
        public int Goal_away { get; set; }
    }
}
