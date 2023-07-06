using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SistemaTurnos.Data.Implementations
{
    public class TableRepository : ITableRepository
    {
        readonly UserDbContext _dbContext;

        public TableRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TableRestaurant> GetAll()
        {
            List<TableRestaurant> mesas = _dbContext.TablesRestaurant.ToList();
            return mesas;
        }

        public TableRestaurant GetById(int tableId)
        {
            TableRestaurant mesa = _dbContext.TablesRestaurant.Find(tableId);
            return mesa;
        }

        public void AddTable(TableRestaurant table)
        {
            _dbContext.TablesRestaurant.Add(table);

            _dbContext.SaveChanges();
        }

        public TableRestaurant UpdateTable(TableRestaurant table)
        {
            TableRestaurant mesaExistente = _dbContext.TablesRestaurant.FirstOrDefault(t => t.Id == table.Id);

            if (mesaExistente != null)
            {
                mesaExistente.Capacity = table.Capacity;
                mesaExistente.Disponibility = table.Disponibility;

                _dbContext.SaveChanges();
            }
                return mesaExistente;
        }

        public TableRestaurant DeleteTable(int tableId)
        {
            TableRestaurant mesaABorrar = _dbContext.TablesRestaurant.FirstOrDefault(t => t.Id == tableId);
            if (mesaABorrar != null)
            {
                _dbContext.TablesRestaurant.Remove(mesaABorrar);

                _dbContext.SaveChanges();
            }
            return mesaABorrar;
        }
    }
}

