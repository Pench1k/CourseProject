using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupControllers : Controller
    {
        public readonly IGroupsService _groupsService;
        public GroupControllers(IGroupsService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GroupsDTO>))]
        public IActionResult GetAllGroups()
        {
            var groups = _groupsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(groups);
        }

        [HttpGet("{groupId}")]
        [ProducesResponseType(200, Type = typeof(DepartmentsDTO))]
        public IActionResult GetGroups(int groupId)
        {
            var groups = _groupsService.Get(groupId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(groups);
        }
    }
}
