using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto Get(int userId);
        void Post(UserDto user);
        UserDto Put(UserDto user);
        UserDto Delete(int userId);

        User ValidateUser(string email, string password);

    }
}
