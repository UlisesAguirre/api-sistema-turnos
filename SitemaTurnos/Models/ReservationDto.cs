using SitemaTurnos.Entities;
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

        //public IList<User> Users { get; set; } = new List<User>();
        //public IList<TableRestaurant> TablesRestaurant { get; set; } = new List<TableRestaurant>();
    }
}