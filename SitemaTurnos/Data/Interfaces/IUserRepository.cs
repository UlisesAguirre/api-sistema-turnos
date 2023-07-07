using SitemaTurnos.Entities;

namespace SitemaTurnos.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int userId);
        void AddUser(User user);
        User UpdateUser(User user);
        User UpdateClient(int id, User user);
        User DeleteUser(int userId);
        User? ValidateUser(string email, string password);
    }
}
