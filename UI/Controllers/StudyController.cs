using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class StudyController : Controller
    {
        private readonly IStudyService _studyService;
        public StudyController(IStudyService studyService)
        {
            _studyService = studyService;
        }

        [Authorize]
        [HttpGet("Study/Schedules/{id}")]
        public async Task<IActionResult> Schedule(string id)
        {
            var scheduleList = await _studyService.GetScheduleGroup(id);
            return View(scheduleList);
        }
    }
}
