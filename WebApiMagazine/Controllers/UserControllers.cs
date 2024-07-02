using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : Controller
    {
        private readonly IUserService _userService;
        public UserControllers(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDTO>))]
        public IActionResult GetAllUsers()
        {
            var user = _userService.GetAllUsers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpGet("userName")]
        [ProducesResponseType(200, Type = typeof(UserDTO))]
        public IActionResult GetUser(string userName)
        {
            var userDTO = _userService.GetUserByName(userName);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(userDTO);
        }


    }

}
