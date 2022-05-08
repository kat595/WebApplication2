namespace WebApplication2.Models
{
    public class GetClubDto
    {
        public int Id { get; set; }
        public string Nameclub { get; set; }
        public List<GetFootballerDto> Footballers { get; set;}
    }
}
