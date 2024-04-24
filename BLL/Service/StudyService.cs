using BLL.DTO;
using BLL.Interfaces;
using BLL.ViewModel;
using DAL.Interfaces;

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
        private readonly IUserService _aspNetUserRepository;

        public StudyService(ISlotsRepository slotRepository,
                            ISlotsSchedulesRepository slotsSchedulesRepository,
                            ISchedulesRepository scheduleRepository,
                            IDisciplinesRepository disciplineRepository,
                            IGroupsSchedulesRepository groupsSchedulesRepository,
                            IGroupsRepository groupRepository,
                            IWorkersRepository workerRepository,
                            IUserService aspNetUserRepository)
        {
            _slotRepository = slotRepository;
            _slotsSchedulesRepository = slotsSchedulesRepository;
            _scheduleRepository = scheduleRepository;
            _disciplineRepository = disciplineRepository;
            _groupsSchedulesRepository = groupsSchedulesRepository;
            _groupRepository = groupRepository;
            _workerRepository = workerRepository;
            _aspNetUserRepository = aspNetUserRepository;
        }

        public async Task<List<SlotsShow>> GetScheduleGroup(string id)
        {
            var user = await _aspNetUserRepository.GetUserInfo(id);

            var slots = _slotRepository.GetAll();
            var slotsSchedules = _slotsSchedulesRepository.GetAll();
            var schedules = _scheduleRepository.GetAll();
            var disciplines = _disciplineRepository.GetAll();
            var groupsSchedules = _groupsSchedulesRepository.GetAll();
            var groups = _groupRepository.GetAll();
            var workers = _workerRepository.GetAll();
            var aspNetUsers = await _aspNetUserRepository.GetAllUsers();

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
    }   
}
