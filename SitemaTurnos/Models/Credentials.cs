using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Models
{
    public class Credentials
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
