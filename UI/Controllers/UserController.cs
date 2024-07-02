using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.ViewModel;
using Microsoft.AspNetCore.Identity;
using BLL.DTO;
using DAL.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Text;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStudyService _studyService;
        private readonly IStudentsService _studentsService;
        private readonly HttpClient _httpClient;

        public UserController(IUserService userService, IStudyService studyService, IStudentsService studentsService)
        {
            _userService = userService;
            _studyService = studyService;
            _studentsService = studentsService;
            _httpClient = HttpClientFactory.Create();
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
            // Выполняем GET-запрос к API
            HttpResponseMessage response = await _httpClient.GetAsync($"api/StudentsControllers/groups/{groupId}");

            if (response.IsSuccessStatusCode)
            {
                // Читаем содержимое ответа как строку JSON
                string json = await response.Content.ReadAsStringAsync();

                // Десериализуем JSON в список студентов (предположим, что у вас есть класс Student)
                var students = JsonConvert.DeserializeObject<List<StudentWithUser>>(json);

                // Возвращаем список студентов как результат метода
                return Ok(students);
            }
            else
            {
                // В случае ошибки возвращаем статус ошибки и сообщение
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
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
            string url = $"https://localhost:7226/api/StudentsControllers/Add";

            // Выполняем HTTP PUT запрос
            HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            // Проверяем статус ответа
            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Возвращаем успешный результат
            }
            else
            {
                // В случае ошибки возвращаем статус ошибки и сообщение
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        [HttpPut("User/Update/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] StudentsEdit model)
        {
            string url = $"https://localhost:7226/api/StudentsControllers/Update/{id}";

            // Выполняем HTTP PUT запрос
            HttpResponseMessage response = await _httpClient.PutAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            // Проверяем статус ответа
            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Возвращаем успешный результат
            }
            else
            {
                // В случае ошибки возвращаем статус ошибки и сообщение
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        [HttpDelete("User/Delete/{id}")]        
        public async Task<IActionResult> DeleteUser(string id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/StudentsControllers/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                // В случае ошибки возвращаем статус ошибки и сообщение
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
