using System.ComponentModel.DataAnnotations;

namespace SitemaTurnos.Entities
{
    public class Restaurant
    {
        [Key]
        public string Name { get; set; }
        public int NumberOfTable { get; set; }
        public string Adress { get; set; }
        public double Phone { get; set; }
        public int Starthour { get; set; } //Consultar
        public int Endhour { get; set; } //Consultar
        public int ReservDuration { get; set; } //Consultar
        public int availableTables { get; set; }


    }
}
