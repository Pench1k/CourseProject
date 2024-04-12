using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class SlotsSchedulesService : ISlotsSchedulesService
    {
        private readonly ISlotsSchedulesRepository _slotsSchedulesRepository;
        private readonly IMapper _mapper;
        public SlotsSchedulesService(ISlotsSchedulesRepository slotsSchedulesRepository, IMapper mapper)
        {
            _slotsSchedulesRepository = slotsSchedulesRepository;
            _mapper = mapper;
        }

        public void Create(SlotsSchedulesDTO entity) => _slotsSchedulesRepository.Create(_mapper.Map<SlotsSchedules>(entity));


        public void Delete(int id) => _slotsSchedulesRepository.Get(id);


        public SlotsSchedulesDTO Get(int id) => _mapper.Map<SlotsSchedulesDTO>(_slotsSchedulesRepository.Get(id));


        public List<SlotsSchedulesDTO> GetAll() => _mapper.Map<List<SlotsSchedulesDTO>>(_slotsSchedulesRepository.GetAll());


        public void Update(SlotsSchedulesDTO entity) => _slotsSchedulesRepository.Update(_mapper.Map<SlotsSchedules>(entity));

    }
}
