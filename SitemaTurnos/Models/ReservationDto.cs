using SitemaTurnos.Enums;

namespace RestaurantReservations.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public int NumOfPeople { get; set; }
        public int IdTable { get; set; }
        public int IdClient { get; set; }
        public Disponibility ReservStatus { get; set; }
    }
}

/*reserva {
    fecha y hora
    cantidad de personas
    mesa asignada
    cliente que reservó
    estado de la reserva(confirmada, cancelada, pendiente)
}*/