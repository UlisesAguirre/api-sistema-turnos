using Microsoft.EntityFrameworkCore;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;

namespace SitemaTurnos.Data.Implementations
{
    public class UserRepository : IUserRepository
    {
        //Usuarios hardcodeados:
         static List<User> users = new List<User>
            {
                new User { Id = 1, Name = "John", LastName = "Doe", Email = "john.doe@example.com", UserType = "Admin" },
                new User { Id = 2, Name = "Emma", LastName = "Smith", Email = "emma.smith@example.com", UserType = "Client" },
                new User { Id = 3, Name = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", UserType = "Client" },
                new User { Id = 4, Name = "Sophia", LastName = "Brown", Email = "sophia.brown@example.com", UserType = "Admin" },
                new User { Id = 5, Name = "Robert", LastName = "Lee", Email = "robert.lee@example.com", UserType = "Manager" }
            };

        readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAll()
        {
            List<User> usuarios = _dbContext.Users.ToList();
            //List<User> usuarios = users.ToList();
            return usuarios;
        }

        public User GetById(int userId)
        {
            //User usuario = _dbContext.Users.Find(userId);
            User usuario = users.Find(q => q.Id == userId);
            return usuario;
        }

        public void AddUser(User user)
        {
            //_dbContext.users.Add(user);
            //_dbContext.SaveChanges();
            users.Add(user);
        }

        public User UpdateUser(User user)
        {
            User usuarioExistente = users.FirstOrDefault(u => u.Id == user.Id);

            if (usuarioExistente != null)
            {
                usuarioExistente.Name = user.Name;
                usuarioExistente.LastName = user.LastName;
                usuarioExistente.Email = user.Email;
                usuarioExistente.UserType = user.UserType;
            }
            return usuarioExistente;
        }

        public User DeleteUser(int userId)
        {
            User usuarioABorrar = users.FirstOrDefault(u => u.Id == userId);
            if (usuarioABorrar != null)
            {
                users.Remove(usuarioABorrar);
            }

            return usuarioABorrar;
        }
    }
}
