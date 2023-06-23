using SistemaTurnos.Data.Implementations;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Services.Implementations
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public List<TableRestaurant> GetTables()
        {
            List<TableRestaurant> mesas = _tableRepository.GetAll();
            return mesas;
        }

        public TableRestaurant Get(int tableId)
        {
            TableRestaurant mesa = _tableRepository.GetById(tableId);
            return mesa;
        }


        public void Post(TableRestaurant table)
        {
            _tableRepository.AddTable(table);
        }


        public TableRestaurant Put(TableRestaurant table)
        {
            TableRestaurant mesa = _tableRepository.UpdateTable(table);
            return mesa;
        }

        public TableRestaurant Delete(int tableId)
        {
            TableRestaurant mesaABorrar = _tableRepository.DeleteTable(tableId);
            return mesaABorrar;
        }
    }
}
