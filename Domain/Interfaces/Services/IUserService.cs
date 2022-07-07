using Domain.DTOs.Users;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserByUserName(string userName);
        Task CreateUser(RegisterRequestDto registerRequest);
        Task<User> Login(LoginRequestDto loginRequest);
    }
}
