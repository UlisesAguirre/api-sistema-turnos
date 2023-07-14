using SistemaTurnos.Enums;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
using System.Text.Json.Serialization;

namespace RestaurantReservations.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Turns turn { get; set; }
        public int NumOfPeople { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Disponibility ReservStatus { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int TableId { get; set; }
        [JsonIgnore]
        public TableRestaurant Table { get; set; }
    }
}