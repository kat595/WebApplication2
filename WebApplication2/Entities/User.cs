namespace WebApplication2.Entities
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nick { get; set; }
        public int Ifadmin { get; set; }
        public List<Tip> Tips { get; set; }
        public List<League> Leagues { get; set; } 
    }
}
