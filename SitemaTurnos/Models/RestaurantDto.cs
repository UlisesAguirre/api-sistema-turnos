using SitemaTurnos.Entities;

namespace RestaurantReservations.Models
{
    public class RestaurantDto
    {
        public string Name { get; set; }
        public int NumberOfTable { get; set; }
        public string Adress { get; set; }
        public double Phone { get; set; }
        public int Starthour { get; set; }
        public int Endhour { get; set; }
        public int ReservDuration { get; set; }
        public int availableTables { get; set; }
        public List<TableRestaurant> tables { get; set; } = new List<TableRestaurant>();

    }
}
