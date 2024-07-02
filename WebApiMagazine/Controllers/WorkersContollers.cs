using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    public class WorkersContollers : Controller
    {
        private readonly IWorkersService _workersService;

        public WorkersContollers(IWorkersService workersService)
        {
            _workersService = workersService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<WorkersDTO>))]
        public IActionResult GetAllWorkers()
        {
            var workers = _workersService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workers);
        }

        [HttpGet("workersId")]
        [ProducesResponseType(200, Type = typeof(WorkersDTO))]
        public IActionResult GetWorkers(int workersId)
        {
            var workers = _workersService.Get(workersId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(workers);
        }
    }
}
