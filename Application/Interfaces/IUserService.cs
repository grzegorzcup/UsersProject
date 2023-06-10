using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUser(int id);

        UserDto RegisterUser(RegisterDto user);
    }
}
