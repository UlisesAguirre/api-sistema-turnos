using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Enums;
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
            List<TableRestaurant> mesas = _dbContext.TablesRestaurant.Include(u => u.Reservations).ToList();
            return mesas;
        }

        public TableRestaurant GetById(int tableId)
        {
            TableRestaurant mesa = _dbContext.TablesRestaurant.Include(u => u.Reservations).FirstOrDefault(u => u.Id == tableId);
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
        public List<TableRestaurant> TablesForDate(DateTime date, Disponibility disponibility, Turns turn, string userRole)
        {
            if (userRole != "Admin")
            {
                List<Reservation> reservationsForDate = _dbContext.Reservations.Where(r => r.DateReservation == date && r.ReservStatus == Disponibility.Disponible && r.turn == turn).ToList();
                
                List<int> tableIds = reservationsForDate.Select(r => r.TableId).ToList();

                List<TableRestaurant> tables = _dbContext.TablesRestaurant.Where(t => tableIds.Contains(t.Id)).ToList();

                foreach (TableRestaurant table in tables)
                {
                    table.Disponibility = Disponibility.Disponible;
                }

                return tables;
            }
            List<Reservation> reservationsForDateAdmin = _dbContext.Reservations.Where(r => r.DateReservation == date && r.ReservStatus == disponibility && r.turn == turn).ToList();

            List<int> tableIdsAdmin = reservationsForDateAdmin.Select(r => r.TableId).ToList();

            List<TableRestaurant> tablesAdmin = _dbContext.TablesRestaurant.Where(t => tableIdsAdmin.Contains(t.Id)).ToList();

            foreach (TableRestaurant table in tablesAdmin)
            {
                Reservation reservation = _dbContext.Reservations.FirstOrDefault(r => r.TableId == table.Id && r.DateReservation == date && r.turn == turn);
                if (reservation.ReservStatus != Disponibility.Reservado)
                {
                    table.Disponibility = Disponibility.Disponible;
                } else
                {
                    table.Disponibility = Disponibility.Reservado;
                }
            }

            return tablesAdmin;
        }
    }
}

