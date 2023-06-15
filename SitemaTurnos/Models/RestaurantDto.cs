namespace RestaurantReservations.Models
{
    public class RestaurantDto
    {
        public int NumberOfTable { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public DateTime Starthour { get; set; }
        public DateTime Endhour { get; set; }
        public DateTime ReservDuration { get; set; }
        public bool Disponibility { get; set; }
           
    }
}

/*info del restaurante {
    numero de Mesas
    nombre
    direccion
    telefono
    correo electronico
    horarios
    disponibilidad
    }*/
