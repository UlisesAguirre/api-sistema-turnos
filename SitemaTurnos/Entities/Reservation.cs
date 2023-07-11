using SitemaTurnos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SitemaTurnos.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public int NumOfPeople { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Disponibility ReservStatus { get; set; }
        [ForeignKey("TableRestaurant")]
        public int TableId { get; set; }
        public TableRestaurant Table { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
