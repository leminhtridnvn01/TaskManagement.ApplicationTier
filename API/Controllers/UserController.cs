using Domain.Users;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.ApplicationTier.API.Controllers;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        //private readonly IUserRepository _userRepository;
        //public UserController(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<User>> Get()
        //{
        //    return Ok(_userRepository.ListAsync(s => s.));
        //}

        [Authorize]
        [HttpGet]
        [Route("{username}")]
        public async Task<ActionResult<User>> Get([FromServices] IUserRepository _userRepository, [FromRoute] string username)
        {
            var member = await _userRepository.GetAsync(s=>s.UserName == username);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
    }
}
