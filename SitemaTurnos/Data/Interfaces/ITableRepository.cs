using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaTurnos.Enums;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SistemaTurnos.Data.Interfaces
{
    public interface ITableRepository
    {
        List<TableRestaurant> GetAll();
        TableRestaurant GetById(int tableId);
        void AddTable(TableRestaurant table);
        TableRestaurant UpdateTable(TableRestaurant table);
        TableRestaurant DeleteTable(int tableId);
        List<TableRestaurant> TablesForDate(DateTime date, Disponibility disponibility, Turns turn, string userRole);
    }
}
