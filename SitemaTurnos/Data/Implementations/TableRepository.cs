using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SistemaTurnos.Data.Implementations
{
    public class TableRepository : ITableRepository
    {

        static List<TableRestaurant> tables = new List<TableRestaurant>
        {
                new TableRestaurant
                {
                    Id = 1,
                    Capacity = 4,
                    Disponibility = Disponibility.Disponible
                },
                new TableRestaurant
                {
                    Id = 2,
                    Capacity = 3,
                    Disponibility = Disponibility.Cancelado
                },
                new TableRestaurant
                {
                    Id = 3,
                    Capacity = 2,
                    Disponibility = Disponibility.Reservado
                },
                new TableRestaurant
                {
                    Id = 4,
                    Capacity = 1,
                    Disponibility = Disponibility.Cancelado
                }
        };

        public List<TableRestaurant> GetAll()
        {
            List<TableRestaurant> mesas = tables.ToList();
            return mesas;
        }

        public TableRestaurant GetById(int tableId)
        {
            TableRestaurant mesa = tables.Find(t => t.Id == tableId);
            return mesa;
        }

        public void AddTable(TableRestaurant table)
        {
            tables.Add(table);
        }

        public TableRestaurant UpdateTable(TableRestaurant table)
        {
            TableRestaurant mesaExistente = tables.FirstOrDefault(t => t.Id == table.Id);

            if (mesaExistente != null)
            {
                mesaExistente.Capacity = table.Capacity;
                mesaExistente.Disponibility = table.Disponibility;
            }
                return mesaExistente;
        }

        public TableRestaurant DeleteTable(int tableId)
        {
            TableRestaurant mesaABorrar = tables.FirstOrDefault(t => t.Id == tableId);
            if (mesaABorrar != null)
            {
                tables.Remove(mesaABorrar);
            }
            return mesaABorrar;
        }
    }
}

