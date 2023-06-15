using System.Net;

namespace RestaurantReservations.Models
{
    public class ClientDto : UserDto
    {
        public int Phone { get; set; }
    }
}

/*Cliente {
            telefono
            direccion
            correo electronico
            nombrecompleto
            edad
            dni
            reservas -historial de reservas

        }*/