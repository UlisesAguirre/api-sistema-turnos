using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Services.Interfaces
{
    public interface ITableService
    {
        List<TableDto> GetTables();
        TableDto Get(int tableId);
        void Post(TableDto table);
        TableDto Put(TableDto table);
        TableDto Delete(int tableId);

    }
}
