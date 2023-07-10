using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace RestaurantReservations.Models
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Disponibility Disponibility { get; set; }
        //public IList<Reservation> ReservationsAssigned { get; set; } = new List<Reservation>();

    }
}
