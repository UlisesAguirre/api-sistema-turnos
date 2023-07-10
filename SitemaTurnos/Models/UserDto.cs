using SitemaTurnos.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservations.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        //public IList<Reservation> ReservationsDone { get; set; } = new List<Reservation>();

    }
}

/*Usuario {
    Id
    nombre de Usuario
    email
    contraseña
}*/
