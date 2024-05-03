using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.ViewModel;
using Microsoft.AspNetCore.Identity;
using BLL.DTO;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStudyService _studyService;
        private readonly IStudentsService _studentsService;

        public UserController(IUserService userService, IStudyService studyService, IStudentsService studentsService)
        {
            _userService = userService;
            _studyService = studyService;
            _studentsService = studentsService;
        }

        [AllowAnonymous]
        [HttpPost("/User/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(string userName, string password)
        {
            var user = await _userService.LoginUser(userName, password);
            if (user != null)
            {

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

        [Authorize(Roles = "Заместитель кафедры")]
        public async Task<IActionResult> Students()
        {
            return View();
        }

        [Authorize(Roles = "Заместитель кафедры")]
        [HttpGet("/User/GetUsers")]
        public async Task<IActionResult> GetStudents([FromQuery] int groupId)
        {
            var students = await _studyService.StudentWithUsers(groupId);
            return Json(students);
        }

        [Authorize(Roles = "Заместитель кафедры")]
        [HttpPost("/User/EditStudent")]
        public async Task<IActionResult> EditStudents([FromBody] StudentWithUser model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("/User/Add")]       
        public async Task<IActionResult> AddUser([FromBody] StudentsCrud model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetUserByName(model.UserName) != null)
                {
                    return StatusCode(500, "User with that username already exists.");
                }
                var user = new UserDTO { UserName = model.UserName, Surname = model.Surname, Name =model.Name, MiddleName = model.MiddleName};
                var result = await _userService.CreateUser(user, model.Password);
                if (result.Succeeded)
                {
                    
                    await _userService.AddRoleToUser(user.Id, "Студент");
                    StudentsDTO studentsDTO = new StudentsDTO
                    {
                        UserId = user.Id,
                        GroupsId = model.GroupId,
                    };
                    _studentsService.Create(studentsDTO);
                    return StatusCode(200, "User added successfully.");                 
                }
                else
                {
                    return StatusCode(500, "User не добавлен.");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The data you have specified is not correct:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;
                return StatusCode(500, errorText);              
            }
        }

        [HttpPut("User/Update/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] StudentsEdit model)
        {
            var user = await _userService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Пользователь с {id} не был найден.");
            }

            if (ModelState.IsValid)
            {
                user.UserName = model.UserName;               
                user.Surname = model.Surname;
                user.Name = model.Name;
                user.MiddleName = model.MiddleName;

                var result = await _userService.UpdateAsync(user);

                if (result.Succeeded)
                {

                    if (model.Password.Length > 6)
                    {
                        await _userService.RemovePasswordAsync(user);
                        await _userService.AddPasswordAsync(user, model.Password);
                    }
                    return StatusCode(200, "Пользователь успешно обновлен.");
                }

                string errorText = "Ошибки которые возникили при редактирование студента:" + Environment.NewLine;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorText += error.Description + Environment.NewLine;
                }

                return StatusCode(500, errorText);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The data you have specified is not correct:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;

                return StatusCode(500, errorText);
            }
        }

        [HttpDelete("User/Delete/{id}")]        
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userService.DeleteUser(user);

                if (result.Succeeded)
                {
                    // Пользователь успешно удален
                    return StatusCode(200, "User deleted successfully.");
                }

                string errorText = "Some errors were occured while trying to DELETE user:" + Environment.NewLine;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorText += error.Description + Environment.NewLine;
                }

                return StatusCode(500, errorText);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorText = "The error while deleting user was occured:" + Environment.NewLine;
                foreach (var error in errors) errorText += error + Environment.NewLine;

                return StatusCode(500, errorText);
            }
        }
    }
}
