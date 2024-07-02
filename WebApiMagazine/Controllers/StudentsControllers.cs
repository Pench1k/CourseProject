using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsControllers : Controller
    {
        private readonly IStudentsService _studentsService;
        private readonly IStudyService _studyService;
        private readonly IUserService _userService; 
        public StudentsControllers(IStudentsService studentsService, IStudyService studyService, IUserService userService)
        {
            _studentsService = studentsService;
            _studyService = studyService;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<StudentsDTO>))]
        public IActionResult GetAllStudents()
        {
            var students = _studentsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(students);
        }

        [HttpGet("{studentsId}")]
        [ProducesResponseType(200, Type = typeof(StudentsDTO))]
        public IActionResult GetStudent(int studentsId)
        {
            var studentsDTO = _studentsService.Get(studentsId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(studentsDTO);
        }

        [HttpGet("groups/{groupsId}")]
        [ProducesResponseType(200, Type = typeof(List<StudentWithUser>))]
        public async Task<IActionResult> GetStudentsWithUser(int groupsId)
        {
            var studentWithUser = await _studyService.StudentWithUsers(groupsId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(studentWithUser);
        }

        [HttpDelete("Delete/{id}")]
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

        [HttpPut("Update/{id}")]
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

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser([FromBody] StudentsCrud model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetUserByName(model.UserName) != null)
                {
                    return StatusCode(500, "User with that username already exists.");
                }
                var user = new UserDTO { UserName = model.UserName, Surname = model.Surname, Name = model.Name, MiddleName = model.MiddleName };
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
    }
}
