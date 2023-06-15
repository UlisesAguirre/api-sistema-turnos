using SitemaTurnos.Enums;

namespace RestaurantReservations.Models
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Capacity { get; } = 4;
        public Disponibility Disponibility { get; set; }

    }
}

/*capacidad, disponibilidad, ubicacion(pa, pb, terraza, patio)*/