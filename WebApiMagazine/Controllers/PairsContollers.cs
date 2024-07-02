using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairsContollers : Controller
    {
        private readonly IPairsService _pairsService;

        public PairsContollers(IPairsService pairsService)
        {
            _pairsService = pairsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PairsDTO>))]
        public IActionResult GetAllPairs()
        {
            var pairs = _pairsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pairs);
        }

        [HttpGet("{pairsId}")]
        [ProducesResponseType(200, Type = typeof(PairsDTO))]
        public IActionResult GetPairs(int pairsId) 
        {
            var pairs = _pairsService.Get(pairsId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pairs);
        }
    }
}
