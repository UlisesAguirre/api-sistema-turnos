using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaTurnos.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
