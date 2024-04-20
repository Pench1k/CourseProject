using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BLL.DTO;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("/User/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(string userName,  string password)
        {
            var user = await _userService.LoginUser(userName, password);
            if (user != null) {
                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }
        
    }
}
