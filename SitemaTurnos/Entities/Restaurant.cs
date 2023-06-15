namespace SitemaTurnos.Entities
{
    public class Restaurant
    {
        public int NumberOfTable { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public DateTime Starthour { get; set; } //Consultar
        public DateTime Endhour { get; set; } //Consultar
        public DateTime ReservDuration { get; set; } //Consultar
        public bool Disponibility { get; set; }


        public ICollection<Table> tablesReserved { get; set; } = new List<Table>();
    }
}
