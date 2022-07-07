using API.Services;
using Domain.DTOs.Users;
using Domain.Interfaces.Services;
using Domain.Users;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.ApplicationTier.API.Controllers;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly EFContext _context;
        public AccountController(EFContext context)
        {
            _context = context;

        }
        [HttpPost("Register")]
        public async Task<ActionResult<string>> RegisterAsync([FromServices] IUserService _userService, [FromServices] ITokenService _tokenService, RegisterRequestDto registerDto)
        {
            var user = await _userService.GetUserByUserName(registerDto.UserName);
            if ( user != null)
            {
                return BadRequest("Username is exited!");
            }
            await _userService.CreateUser(registerDto);
            return Ok(new UserResponseDto
            {
                Username = registerDto.UserName,
                Token = _tokenService.CreateToken(user)
            });
            //return Ok("I'm TOken");

        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromServices] IUserService _userService, [FromServices] ITokenService _tokenService, LoginRequestDto loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            if (await _userService.Login(loginRequest) == null)
            {
                return Unauthorized("Invalid Username or Password");
            }
            return Ok(new UserResponseDto
            {
                Username = loginRequest.UserName,
                Token = _tokenService.CreateToken(user)
            });
            //return Ok("I'm TOken");
        }
    }
}
