using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserDto> GetUsers()
        {
            List<User> usuarios = _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(usuarios);
        }

        public UserDto Get(int userId)
        {
            var usuario = _userRepository.GetById(userId);
            return _mapper.Map<UserDto>(usuario);
        }


        public void Post(UserDto user)
        {
            User usuario = _mapper.Map<User>(user);
            _userRepository.AddUser(usuario);
        }


        public UserDto Put(UserDto user)
        {
            User usuario = _mapper.Map<User>(user);
            User usuariomodified = _userRepository.UpdateUser(usuario);
            return _mapper.Map<UserDto>(usuariomodified);
        }
        public UserDto Delete(int userId)
        {
            User usuarioABorrar = _userRepository.DeleteUser(userId);
            return _mapper.Map<UserDto>(usuarioABorrar);
        }

        public User ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            return _userRepository.ValidateUser(email, password); 
        }
    }
}
