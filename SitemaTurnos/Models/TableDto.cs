using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantReservations.Models
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Disponibility Disponibility { get; set; }
        public List<ReservationDto> Reservations { get; } = new List<ReservationDto>();

    }
}
