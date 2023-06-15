namespace SitemaTurnos.Entities
{
    public class Client
    {
        public int Phone { get; set; }

        public ICollection<Reservation> ReservationsDone { get; set; } = new List<Reservation>();
    }
}
