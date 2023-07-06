using SitemaTurnos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaTurnos.Entities
{
    public class TableRestaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Disponibility Disponibility { get; set; }

        //public ICollection<Reservation> ReservationsAssigned { get; set; } = new List<Reservation>();

    }
}
