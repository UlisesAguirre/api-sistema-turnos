namespace RestaurantReservations.Models
{
    public class Reservation
    {
//        reserva {
//    fecha y hora
//    cantidad de personas
//    mesa asignada
//    cliente que reservó
//    estado de la reserva(confirmada, cancelada, pendiente)
//} 
    
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public int NumbOfPeople { get; set; }
        public int IdTable { get; set; }
        public int IdClient { get; set; }
        public Enum ReservStatus { get; set; } // GOOGLEAR <---------
    }
}
