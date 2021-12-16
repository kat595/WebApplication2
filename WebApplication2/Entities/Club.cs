namespace WebApplication2.Entities
{
    public class Club
    {
        public int Id { get; set; } 
        public string Nameclub { get; set; }
        public List<Footballer> Footballers { get; set; }
    }
}
