namespace RestaurantReservations.Models
{
    public class Restaurant
    {
    //    info del restaurante {
    //numero de Mesas
    //nombre
    //direccion
    //telefono
    //correo electronico
    //horarios
    //disponibilidad
    //}

        public int NumberOfTable { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public DateTime Starthour { get; set; } //Consultar
        public DateTime Endhour { get; set; } //Consultar
        public DateTime ReservDuration { get; set; } //Consultar
        public bool Disponibility { get; set; }
           
}
}
