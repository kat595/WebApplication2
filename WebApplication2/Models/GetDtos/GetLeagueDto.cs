namespace WebApplication2.Models
{
    public class GetLeagueDto
    {
        public string League_name { get; set; }
        public DateTime Creation_date { get; set; }
        public virtual List<GetUserDto> Users { get; set; }
        public virtual List<GetUserDto> Founders { get; set; }
    }
}
