using AutoMapper;
using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();
        }
    }
}
