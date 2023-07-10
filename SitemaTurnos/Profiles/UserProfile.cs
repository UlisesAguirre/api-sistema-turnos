using AutoMapper;
using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
