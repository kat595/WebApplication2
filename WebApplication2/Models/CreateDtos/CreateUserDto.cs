using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Nick { get; set; }
        
        [Required]
        public string Password { get; set; }
        public int Ifadmin { get; set; } = 0;
    }
}
