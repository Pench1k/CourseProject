
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class SchedulesService : ISchedulesService
    {
        private readonly ISchedulesReporitory _schedulesRepository;
        private readonly IDisciplinesService _disciplinesService;
        private readonly IGroupsService _groupsService;
        private readonly IMapper _mapper;
        public SchedulesService(ISchedulesReporitory schedulesRepository, IDisciplinesService disciplinesService, IGroupsService groupsService, IMapper mapper)
        {
            _schedulesRepository = schedulesRepository;
            _disciplinesService = disciplinesService;
            _groupsService = groupsService;
            _mapper = mapper;
        }

        public void Create(SchedulesDTO entity) => _schedulesRepository.Create(_mapper.Map<Schedules>(entity));


        public void Delete(int id) => _schedulesRepository.Delete(id);


        public SchedulesDTO Get(int id) => _mapper.Map<SchedulesDTO>(_schedulesRepository.Get(id));


        public List<SchedulesDTO> GetAll() => _mapper.Map<List<SchedulesDTO>>(_schedulesRepository.GetAll());


        public void Update(SchedulesDTO entity) => _schedulesRepository.Update(_mapper.Map<Schedules>(entity));

        public List<SchedulesDTO>? SchedulesWithDisciplineGetAll()
        {
            var schedules = GetAll();
            foreach(var schedule in schedules) {
                schedule.Disciplines = _disciplinesService.Get(schedule.DisciplinesId);
            }
            return schedules;
        }

    }
}
