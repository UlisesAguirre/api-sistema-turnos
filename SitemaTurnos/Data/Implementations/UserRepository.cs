using Microsoft.EntityFrameworkCore;
using RestaurantReservations.Models;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;

namespace SitemaTurnos.Data.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAll()
        {
            List<User> usuarios = _dbContext.Users.ToList();
            return usuarios;
        }

        public User GetById(int userId)
        {
            var usuario = _dbContext.Users.Find(userId);
            return usuario;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User UpdateUser(User user)
        {
            User usuarioExistente = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            if (usuarioExistente != null)
            {
                usuarioExistente.Name = user.Name;
                usuarioExistente.LastName = user.LastName;
                usuarioExistente.Email = user.Email;
                usuarioExistente.UserType = user.UserType;

                _dbContext.SaveChanges();
            }
            return usuarioExistente;
        }

        public User DeleteUser(int userId)
        {
            User usuarioABorrar = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (usuarioABorrar != null)
            {
                _dbContext.Users.Remove(usuarioABorrar);


                _dbContext.SaveChanges();
            }

            return usuarioABorrar;
        }
        

        //Authentication <-------
        public User? ValidateUser(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
