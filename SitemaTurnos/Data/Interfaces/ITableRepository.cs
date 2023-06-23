using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Data.Interfaces
{
    public interface ITableRepository
    {
        List<TableRestaurant> GetAll();
        TableRestaurant GetById(int tableId);
        void AddTable(TableRestaurant table);
        TableRestaurant UpdateTable(TableRestaurant table);
        TableRestaurant DeleteTable(int tableId);
    }
}
