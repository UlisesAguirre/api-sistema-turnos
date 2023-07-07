using SitemaTurnos.Entities;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User Get(int userId);
        void Post(User user);
        User Put(User user);
        User PutClient(int id, User user);
        User Delete(int userId);

        User ValidateUser(string email, string password);

    }
}
