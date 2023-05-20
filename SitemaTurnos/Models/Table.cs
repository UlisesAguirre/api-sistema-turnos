using System.IO;

namespace RestaurantReservations.Models
{
    public class Table
    {
    
    //capacidad
    //disponibilidad
    //ubicacion(pa, pb, terraza, patio)

        public int Id { get; set; }
        public int Capacity { get; } = 4;
        public bool Disponibilty { get; set; } // ENUM -- GOOGLEAR

    }
}
