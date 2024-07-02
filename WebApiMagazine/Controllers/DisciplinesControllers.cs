using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesControllers : Controller
    {
        private readonly IDisciplinesService _disciplinesService;

        public DisciplinesControllers(IDisciplinesService disciplinesService)
        {
            _disciplinesService = disciplinesService;
        }
        

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DisciplinesDTO>))]
        public IActionResult GetAllDisciplines()
        {
            var disciplines = _disciplinesService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(disciplines);
        }

        [HttpGet("{disciplinesId}")]
        [ProducesResponseType(200, Type = typeof(DepartmentsDTO))]
        public IActionResult GetDisciplines(int disciplinesId)
        {
            var disciplines = _disciplinesService.Get(disciplinesId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(disciplines);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult PostDisciplines([FromQuery] string disciplinesName)
        {
            if(disciplinesName == null)
                return BadRequest(ModelState);
            _disciplinesService.Create(new DisciplinesDTO { DisciplineName = disciplinesName });
            return Ok("Все четко");
        }

        [HttpDelete("{disciplinesId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteDisciplines(int disciplinesId)
        {
            var discipline = _disciplinesService.Get(disciplinesId);
            if (discipline == null)
                return NotFound();
            else
            {
                _disciplinesService.Delete(disciplinesId);
                return Ok("Все четко");
            }
            
        }

        [HttpPut("{disciplinesId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDisciplines(int disciplinesId, [FromBody] string disciplineName)
        {
            if (string.IsNullOrEmpty(disciplineName))
            {
                return BadRequest("Invalid discipline name"); 
            }
            var existingDiscipline = _disciplinesService.Get(disciplinesId);
            if (existingDiscipline == null)
            {
                return NotFound(); 
            }        
            existingDiscipline.DisciplineName = disciplineName;
            _disciplinesService.Update(existingDiscipline);           
            return NoContent();
        }


    }
}
