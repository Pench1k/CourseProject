using BLL.DTO;
using BLL.Interfaces;
using BLL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class StudyController : Controller
    {
        private readonly IStudyService _studyService;
        private readonly IUserService _userService;
        private readonly IMarksService _marksService;
        private readonly IGroupsService _groupsService;
        private readonly ISchedulesService _schedulesService;
        private readonly IDisciplinesService _disciplinesService;
        public StudyController(IStudyService studyService, 
            IUserService userService,
            ISchedulesService schedulesService,
            IMarksService marksService, 
            IGroupsService groupsService,
            IDisciplinesService disciplinesService)
        {
            _studyService = studyService;
            _userService = userService;
            _marksService = marksService;
            _groupsService = groupsService;
            _disciplinesService = disciplinesService;
            _schedulesService = schedulesService;
        }

        [Authorize]
        [HttpGet("Study/Schedules/{id}")]
        public async Task<IActionResult> Schedule(string id)
        {
            var scheduleList = await _studyService.GetScheduleGroup(id);
            //_studyService.GenerateSchedule(new DateTime(2024, 4, 1), new DateTime(2024, 5, 31));
            return View(scheduleList);
        }

        [Authorize(Roles = "Преподаватель")]
        [HttpGet("Study/Omissions/{id}")]
        public async Task<IActionResult> Omissions(string id)
        {
            var user = await _userService.GetUserInfo(id);
            var schedulesForWorker = _studyService.GetSchedulesForWorker(user.Workers.Id);
            return View(schedulesForWorker);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupMembersAndDates(int groupId, int scheduleId)
        {

            var groupMembers = await _studyService.StudentWithUsers(groupId);
            var availableDates = _studyService.GetPairDatesForSchedule(scheduleId);
            // Возврат данных в формате JSON
            return Json(new { groupMembers = groupMembers, availableDates = availableDates });
        }

        [Authorize(Roles = "Преподаватель")]
        [HttpGet("Study/Details/")]
        public async Task<IActionResult> Details(int groupId, int scheduleId)
        {
            var groupMembers = await _studyService.StudentWithUsers(groupId);
            var availableDates = _studyService.GetPairDatesForSchedule(scheduleId);
            var group = _groupsService.Get(groupId);
            var schedules = _schedulesService.Get(scheduleId);
            schedules.Disciplines = _disciplinesService.Get(schedules.DisciplinesId);
            ViewBag.AvailableDates = availableDates;  
            ViewBag.Group = group;
            ViewBag.Schedules = schedules;
            return View(groupMembers);
        }

        [Authorize(Roles = "Преподаватель")]
        [HttpPost]
        public IActionResult SaveMarks([FromBody] MarksViewModel mark)
        {
            var existingMark = _marksService.GetMarkByStudentIdAndPairId(mark.StudentId, mark.PairId);
            if (existingMark != null)           
                _marksService.Delete(existingMark.Id);  
            if(mark.Grade != -1)
            {
                var markEntity = new MarksDTO
                {
                    MarksCount = mark.Grade,
                    StudentId = mark.StudentId,
                    PairsId = mark.PairId
                };
                _marksService.Create(markEntity);
            }          
            return Ok();
        }

        [Authorize]
        [HttpGet("/Study/GetMark")]
        public IActionResult GetMark(int studentId, int pairId)
        {
            var mark = _marksService.GetMarkByStudentIdAndPairId(studentId, pairId);

            if (mark != null)
            {
                // Если оценка найдена, возвращаем ее в формате JSON
                return Json(new { MarksCount = mark.MarksCount });
            }
            else
            {
                // Если оценка не найдена, возвращаем пустой результат
                return Json(null);
            }
        }

        [Authorize]
        [HttpGet("Study/Grade/{id}")]
        public async Task<IActionResult> Grade(string id)
        {
            var student = await _userService.GetUserInfo(id);
            var groupSchedules = await _studyService.GetSchedulesForGroup(student.Groups.Id);

            ViewBag.Student = student;

            return View(groupSchedules);
        }

        [Authorize]
        [HttpGet("Study/DetailsForStudent/")]
        public IActionResult DetailsForStudent(int groupId, int scheduleId, int studentId)
        {
            var availableDates = _studyService.GetPairDatesForSchedule(scheduleId);           
            return Json(new { AvailableDates = availableDates });
        }
    }
}
