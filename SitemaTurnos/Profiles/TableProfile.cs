using AutoMapper;
using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Profiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<TableRestaurant, TableDto>();
            CreateMap<TableDto, TableRestaurant>();
        }
    }
}
