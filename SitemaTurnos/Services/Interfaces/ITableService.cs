using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservations.Models;
using SistemaTurnos.Enums;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SistemaTurnos.Services.Interfaces
{
    public interface ITableService
    {
        List<TableDto> GetTables();
        TableDto Get(int tableId);
        void Post(TableDto table);
        TableDto Put(TableDto table);
        TableDto Delete(int tableId);
        List<TableDto> TablesForDate(DateTime date, Disponibility disponibility,Turns turn, string userRole);

    }
}
