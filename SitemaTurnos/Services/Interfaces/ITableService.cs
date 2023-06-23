using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Services.Interfaces
{
    public interface ITableService
    {
        List<TableRestaurant> GetTables();
        TableRestaurant Get(int tableId);
        void Post(TableRestaurant table);
        TableRestaurant Put(TableRestaurant table);
        TableRestaurant Delete(int tableId);

    }
}
