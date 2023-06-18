using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDto GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            return _mapper.Map<UserDto>(user);
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto RegisterUser(RegisterDto newUser)
        {
            if (string.IsNullOrEmpty(newUser.Name)|| string.IsNullOrEmpty(newUser.Password))
            {
                throw new Exception("login lub hasło jest puste");
            }
            var user = _mapper.Map<User>(newUser);
            _userRepository.Add(user);
            return _mapper.Map<UserDto>(user) ; 
        }
    }
}
