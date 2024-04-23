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
                
                return Ok();
            }
            else
            {
                return BadRequest("Не правильный логин или пароль");
            }
        }

        [Authorize]
        [HttpGet("/User/Profile/{id}")]        
        public async Task<IActionResult> Profile(string id)
        {
            var userDTO = await _userService.GetUserInfo(id);
            return View(userDTO);
        }

        [Authorize]
        [HttpGet("/User/Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _userService.LogoutUser();
            }
            catch { }
            return RedirectToAction("Login", "Home");
        }

    }
}
