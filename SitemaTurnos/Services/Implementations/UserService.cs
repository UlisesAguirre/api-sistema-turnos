using Microsoft.AspNetCore.Mvc;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            List<User> usuarios = _userRepository.GetAll();
            return usuarios;
        }

        public User Get(int userId)
        {
            User usuario = _userRepository.GetById(userId);
            return usuario;
        }


        public void Post(User user)
        {
            _userRepository.AddUser(user);
        }


        public User Put(User user)
        {
            User usuario = _userRepository.UpdateUser(user);
            return usuario;
        }

        public User Delete(int userId)
        {
            User usuarioABorrar = _userRepository.DeleteUser(userId);
            return usuarioABorrar;
        }
    }
}
