using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyesControllers : Controller
    {
        private readonly IFacultyesService _facultyesService;

        public FacultyesControllers(IFacultyesService facultyesService)
        {
            _facultyesService = facultyesService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FacultyesDTO>))]
        public IActionResult GetAllFacultyes()
        {
            var facultyesDTO = _facultyesService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(facultyesDTO);
        }

        [HttpGet("{facultyesId}")]
        [ProducesResponseType(200, Type = typeof(DepartmentsDTO))]
        public IActionResult GetFacultyes(int facultyesId)
        {
            var facultyesDTO = _facultyesService.Get(facultyesId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(facultyesDTO);
        }
    }
}
