using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    public class MarksController : Controller
    {
        private readonly IMarksService _marksService;
        public MarksController(IMarksService marksService)
        {
            _marksService = marksService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MarksDTO>))]
        public IActionResult GetAllMarks()
        {
            var marks = _marksService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(marks);
        }

        [HttpGet("{markId}")]
        [ProducesResponseType(200, Type = typeof(MarksDTO))]
        public IActionResult GetMarks(int markId)
        {
            var marks = _marksService.Get(markId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(marks);
        }
        
    }
}
