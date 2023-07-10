using AutoMapper;
using RestaurantReservations.Models;
using SistemaTurnos.Data.Implementations;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Services.Implementations
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public List<TableDto> GetTables()
        {
            List<TableRestaurant> tables = _tableRepository.GetAll();
            return _mapper.Map<List<TableDto>>(tables);
        }

        public TableDto Get(int tableId)
        {
            TableRestaurant table = _tableRepository.GetById(tableId);
            return _mapper.Map<TableDto>(table);
        }


        public void Post(TableDto table)
        {
            TableRestaurant newTable = _mapper.Map<TableRestaurant>(table);
            _tableRepository.AddTable(newTable);
        }


        public TableDto Put(TableDto table)
        {
            TableRestaurant mesa = _mapper.Map<TableRestaurant>(table);
            TableRestaurant tableModified = _tableRepository.UpdateTable(mesa);

            return _mapper.Map<TableDto>(tableModified);
        }

        public TableDto Delete(int tableId)
        {
            TableRestaurant table = _tableRepository.DeleteTable(tableId);
            return _mapper.Map<TableDto>(table);
        }
    }
}
