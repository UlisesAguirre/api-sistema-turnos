using SitemaTurnos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SitemaTurnos.Entities
{
    public class TableRestaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Capacity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore]
        public Disponibility Disponibility { get; set; }
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
