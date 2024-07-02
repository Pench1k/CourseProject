using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesContollers : Controller
    {
        private readonly ISchedulesService _schedulesService;

        public SchedulesContollers(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SchedulesDTO>))]
        public IActionResult GetAllSchedules()
        {
            var schedules = _schedulesService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(schedules);
        }

        [HttpGet("{schedulesId}")]
        [ProducesResponseType(200, Type = typeof(SchedulesDTO))]
        public IActionResult GetSchedules(int schedulesId) 
        {
            var schedules = _schedulesService.Get(schedulesId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(schedules);
        }

    }
}
