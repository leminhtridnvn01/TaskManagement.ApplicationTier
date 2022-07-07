using Domain.DTOs.Users;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Users;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateUser(RegisterRequestDto registerRequest)
        {
            try
            {
                if (await _userRepository.GetAsync(s => s.UserName == registerRequest.UserName) != null)
                {
                    return;
                }
                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    UserName = registerRequest.UserName.ToLower(),
                    Email = registerRequest.Email,
                    Name = registerRequest.Name,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerRequest.Password)),
                    PasswordSalt = hmac.Key
                };
                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveEntitiesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> GetUserByUserName(string username)
        {
            try
            {
                var user = await _userRepository.GetAsync(s => s.UserName == username);
                return user;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> Login(LoginRequestDto loginRequest)
        {
            try
            {
                var user = await _userRepository.GetAsync(s => s.UserName == loginRequest.UserName.ToLower());

                if (user == null) return null;

                using var hmac = new HMACSHA512(user.PasswordSalt);

                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));

                for (var i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i]) return null;
                }
                return user;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
