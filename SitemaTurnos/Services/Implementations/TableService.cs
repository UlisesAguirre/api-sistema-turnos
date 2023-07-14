using AutoMapper;
using RestaurantReservations.Models;
using SistemaTurnos.Data.Implementations;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Enums;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SistemaTurnos.Services.Implementations
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public TableService(ITableRepository tableRepository,IReservationRepository reservationRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _reservationRepository = reservationRepository;
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
        public List<TableDto> TablesForDate(DateTime date, Disponibility disponibility,Turns turn, string userRole)
        {

            List<TableRestaurant> tables = _tableRepository.TablesForDate(date, disponibility, turn, userRole);

            foreach (TableRestaurant table in tables)
            {
                table.Reservations = _reservationRepository.GetReservationByTable(table.Id);
            }

            return _mapper.Map<List<TableDto>>(tables);
        }
    }
}
