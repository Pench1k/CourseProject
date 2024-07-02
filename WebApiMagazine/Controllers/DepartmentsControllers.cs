using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsControllers : Controller
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsControllers(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DepartmentsDTO>))]
        public IActionResult GetAllDepartment() 
        {
            var departments = _departmentsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departments);
        }

        [HttpGet("{departmentId}")]
        [ProducesResponseType(200, Type = typeof(DepartmentsDTO))]
        public IActionResult GetDepartment(int departmentId)
        {
            var departments = _departmentsService.Get(departmentId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(departments);
        }
        

    }
}
