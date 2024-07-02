using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotControllers : Controller
    {
        private readonly ISlotsService _slotsService;
        public SlotControllers(ISlotsService slotsService)
        {
            _slotsService = slotsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<SlotsDTO>))]
        public IActionResult GetAllSlots ()
        {
            var slots = _slotsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(slots);
        }

        [HttpGet("{slotsId}")]
        [ProducesResponseType(200, Type = typeof(SlotsDTO))]
        public IActionResult GetSlot(int slotsId)
        {
            var slots = _slotsService.Get(slotsId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(slots);
        }
    }
}
