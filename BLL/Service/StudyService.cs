using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.ViewModel;
using DAL.Interfaces;
using DAL.Models;
using DAL.SQLRepository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BLL.Service
{
    public class StudyService : IStudyService
    {
        private readonly ISlotsRepository _slotRepository;
        private readonly ISlotsSchedulesRepository _slotsSchedulesRepository;
        private readonly ISchedulesRepository _scheduleRepository;
        private readonly IDisciplinesRepository _disciplineRepository;
        private readonly IGroupsRepository _groupRepository;
        private readonly IWorkersRepository _workerRepository;
        private readonly IGroupsSchedulesRepository _groupsSchedulesRepository;
        private readonly IUserService _aspNetUserService;
        private readonly IPairsRepository _pairsRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMarksRepository _marksRepository;
        private readonly IMapper _mapper;
        public StudyService(ISlotsRepository slotRepository,
                            ISlotsSchedulesRepository slotsSchedulesRepository,
                            ISchedulesRepository scheduleRepository,
                            IDisciplinesRepository disciplineRepository,
                            IGroupsSchedulesRepository groupsSchedulesRepository,
                            IGroupsRepository groupRepository,
                            IWorkersRepository workerRepository,
                            IUserService aspNetUserRepository,
                            IPairsRepository pairsRepository,
                            IStudentsRepository studentsRepository,
                            IMarksRepository marksRepository,
                            IMapper mapper)
        {
            _slotRepository = slotRepository;
            _slotsSchedulesRepository = slotsSchedulesRepository;
            _scheduleRepository = scheduleRepository;
            _disciplineRepository = disciplineRepository;
            _groupsSchedulesRepository = groupsSchedulesRepository;
            _groupRepository = groupRepository;
            _workerRepository = workerRepository;
            _pairsRepository = pairsRepository;
            _aspNetUserService = aspNetUserRepository;
            _studentsRepository = studentsRepository;
            _marksRepository = marksRepository;
            _mapper = mapper;
        }

        public async Task<List<SlotsShow>> GetScheduleGroup(string id)
        {
            var user = await _aspNetUserService.GetUserInfo(id);

            var slots = _slotRepository.GetAll();
            var slotsSchedules = _slotsSchedulesRepository.GetAll();
            var schedules = _scheduleRepository.GetAll();
            var disciplines = _disciplineRepository.GetAll();
            var groupsSchedules = _groupsSchedulesRepository.GetAll();
            var groups = _groupRepository.GetAll();
            var workers = _workerRepository.GetAll();
            var aspNetUsers = await _aspNetUserService.GetAllUsers();

            var query = from slot in slots
                        join slotSchedule in slotsSchedules on slot.Id equals slotSchedule.SlotsId into slotSchedulesGroup
                        from slotSchedule in slotSchedulesGroup.DefaultIfEmpty()
                        join schedule in schedules on (slotSchedule != null ? slotSchedule.SchedulesId : default(int)) equals schedule.Id into schedulesGroup
                        from schedule in schedulesGroup.DefaultIfEmpty()
                        join discipline in disciplines on (schedule != null ? schedule.DisciplinesId : default(int)) equals discipline.Id into disciplinesGroup
                        from discipline in disciplinesGroup.DefaultIfEmpty()
                        join groupSchedule in groupsSchedules on (schedule != null ? schedule.Id : default(int)) equals groupSchedule.SchedulesId into groupSchedulesGroup
                        from groupSchedule in groupSchedulesGroup.DefaultIfEmpty()
                        join groupItem in groups on (groupSchedule != null ? groupSchedule.GroupsId : default(int)) equals groupItem.Id into groupsGroup
                        from groupItem in groupsGroup.DefaultIfEmpty()
                        join worker in workers on (schedule != null ? schedule.WorkerId : null) equals worker.Id into workersGroup
                        from worker in workersGroup.DefaultIfEmpty()
                        join aspNetUser in aspNetUsers on (worker != null ? worker.UserId : null) equals aspNetUser.Id into aspNetUsersGroup
                        from aspNetUser in aspNetUsersGroup.DefaultIfEmpty()
                            //where (groupItem != null ? groupItem.Id : null) == user.Groups.Id
                        where (user.Role[0] == "Студент" && (groupItem != null ? groupItem.Id : null) == user.Groups.Id) ||
                        (user.Role[0] != "Студент" && worker != null && worker.Id == user.Workers.Id)
                        select new SlotsShow
                        {
                            DayOfTheWeek = slot.DayOfTheWeek,
                            StartTime = slot.Start,
                            EndTime = slot.End,
                            GroupName = groupItem?.NameGroup,
                            Course = groupItem?.Course,
                            GroupNumber = groupItem?.NumberGroup,
                            WorkerSurname = aspNetUser?.Surname,
                            TypeSchedule = schedule?.TypeSchedule,
                            DisciplineName = discipline?.DisciplineName,
                            WorkerId = (schedule != null ? schedule.WorkerId : null)
                        };


            return query.ToList();
        }

        public void GenerateSchedule(DateTime startDate, DateTime endDate)
        {
            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                int dayOfWeek = (int)i.DayOfWeek;
                if (dayOfWeek > 0 && dayOfWeek < 6)
                {
                    List<int> slotSchedulesId = _slotsSchedulesRepository.GetSlotsSchedulesIdsForDayOfWeek(dayOfWeek);
                    foreach (var item in slotSchedulesId)
                    {
                        Pairs pairs = new Pairs
                        {
                            SlotScheduleId = item,
                            TypePair = TypePair.Прошла,
                            Date = i.Date,
                        };
                        _pairsRepository.Create(pairs);
                    }
                }
            }
        }

        public List<SchedulesForTeacher> GetSchedulesForWorker(int workerId)
        {
            var schedules = _scheduleRepository.GetAll();
            var workers = _workerRepository.GetAll();
            var disciplines = _disciplineRepository.GetAll();
            var groupsSchedules = _groupsSchedulesRepository.GetAll();
            var groups = _groupRepository.GetAll();


            var query = from schedule in schedules
                        join worker in workers on schedule.WorkerId equals worker.Id
                        join discipline in disciplines on schedule.DisciplinesId equals discipline.Id
                        join groupSchedule in groupsSchedules on schedule.Id equals groupSchedule.SchedulesId
                        join groupItem in groups on groupSchedule.GroupsId equals groupItem.Id
                        where schedule.WorkerId == workerId
                        select new SchedulesForTeacher
                        {
                            WorkerId = schedule.WorkerId,
                            GroupId = groupItem.Id,
                            GroupName = groupItem.NameGroup,
                            Course = groupItem.Course,
                            GroupNumber = groupItem.NumberGroup,
                            DisciplineName = discipline.DisciplineName,
                            ScheduleId = schedule.Id,
                            TypeSchedule = schedule.TypeSchedule
                        };

            return query.ToList();
        }

        public async Task<List<StudentWithUser>> StudentWithUsers(int groupId)
        {
            List<Students> students = _studentsRepository.FindAll(x => x.GroupsId == groupId);
            var studentWithUsersList = new List<StudentWithUser>();
            foreach (Students student in students)
            {
                var user = await _aspNetUserService.GetUserInfo(student.UserId);

                studentWithUsersList.Add(new StudentWithUser
                {
                    StudentId = student.Id,
                    GroupId = student.GroupsId,
                    UserId = user.User.Id,
                    Surname = user.User.Surname,
                    Name = user.User.Name,
                    MiddleName = user.User.MiddleName,
                    UserName = user.User.UserName,
                    Password = user.User.PasswordHash
                });
            }
            return studentWithUsersList;
        }

        public List<PairsDTO> GetPairDatesForSchedule(int scheduleId)
        {
            var pairDates = (from pair in _pairsRepository.GetAll()
                             join slotsSchedule in _slotsSchedulesRepository.GetAll() on pair.SlotScheduleId equals slotsSchedule.Id
                             join schedule in _scheduleRepository.GetAll() on slotsSchedule.SchedulesId equals schedule.Id
                             where schedule.Id == scheduleId && pair.Date <= DateTime.Now
                             select pair).ToList();

            return _mapper.Map<List<PairsDTO>>(pairDates);
        }

        public async Task<List<ScheduleForGroupViewModel>> GetSchedulesForGroup(int groupId)
        {
            var schedules = _scheduleRepository.GetAll();
            var workers = _workerRepository.GetAll();
            var disciplines = _disciplineRepository.GetAll();
            var groupsSchedules = _groupsSchedulesRepository.GetAll();
            var groups = _groupRepository.GetAll();
            var users = await _aspNetUserService.GetAllUsers();

            var schedulesForGroup = from groupS in groups
                                    join groupSchedules in groupsSchedules on groupS.Id equals groupSchedules.GroupsId
                                    join schedule in schedules on groupSchedules.SchedulesId equals schedule.Id
                                    join discipline in disciplines on schedule.DisciplinesId equals discipline.Id
                                    join worker in workers on schedule.WorkerId equals worker.Id
                                    join user in users on worker.UserId equals user.Id
                                    where groupS.Id == groupId
                                    select new ScheduleForGroupViewModel
                                    {
                                        WorkerId = worker.Id,
                                        Surname = user.Surname,
                                        Name = user.Name,
                                        MiddleName = user.MiddleName,
                                        ScheduleId = schedule.Id,
                                        GroupId = groupId,
                                        DisciplineName = discipline.DisciplineName,
                                        TypeSchedule = schedule.TypeSchedule,
                                    };

            return schedulesForGroup.ToList();
        }

        public List<GroupsDTO> GetGroupsOnDepartments(int departmentId)
        {
            return _mapper.Map<List<GroupsDTO>>(_groupRepository.FindAll(x => x.DepartmentId == departmentId));
        }
        
        public async Task<List<StudentStatistics>> GetStudentStatistics(int groupId, int schedulesId)
        {
            var students = _studentsRepository.GetAll().Where(s => s.GroupsId == groupId).ToList();
            var marks = _marksRepository.GetAllSecond()
            .Include(m => m.Pairs)
            .ThenInclude(p => p.SlotSchedule)
            .ThenInclude(ss => ss.Schedules)
            .Where(m => m.Pairs.SlotSchedule.Schedules.Id == schedulesId && m.Student.GroupsId == groupId)
            .ToList();

            var users = await _aspNetUserService.GetAllUsers();

            var query = from student in students
                        join user in users on student.UserId equals user.Id
                        join mark in marks on student.Id equals mark.StudentId into markGroup
                        from mark in markGroup.DefaultIfEmpty()
                        group new { student, mark } by new { student.Id, user.Surname, user.Name, user.MiddleName } into g
                        select new StudentStatistics
                        {
                            StudentId = g.Key.Id,
                            Surname = g.Key.Surname,
                            Name = g.Key.Name,
                            MiddleName = g.Key.MiddleName,
                            AverageMark = g.Select(x => x.mark != null && x.mark.MarksCount != 0 ? x.mark.MarksCount : (int?)null).Average(),
                            Absences = g.Sum(x => x.mark != null && x.mark.MarksCount == 0 ? 1 : 0)
                        };

            return query.ToList();
        }
    }
}
