using SitemaTurnos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitemaTurnos.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public int NumOfPeople { get; set; }
        public Disponibility ReservStatus { get; set; }
        [ForeignKey("IdTable")]
        public int IdTable { get; set; }
        [ForeignKey("IdClient")]
        public int IdClient { get; set; }

        //Tengo que agregar alguna lista?
    }
}
