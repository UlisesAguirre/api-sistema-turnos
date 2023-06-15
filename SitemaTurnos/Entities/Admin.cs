namespace SitemaTurnos.Entities
{
    public class Admin: User
    {
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
