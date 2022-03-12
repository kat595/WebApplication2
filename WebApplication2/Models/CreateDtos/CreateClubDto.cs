using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class CreateClubDto
    {
        [Required]
        [MaxLength(50)]
        public string Nameclub { get; set; }
    }
}
