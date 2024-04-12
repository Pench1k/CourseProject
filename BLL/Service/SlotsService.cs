

using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class SlotsService : ISlotsService
    {
        private readonly ISlotsRepository _slotsRepository;
        private readonly IMapper _mapper;
        public SlotsService(ISlotsRepository slotsRepository, IMapper mapper)
        {
            _slotsRepository = slotsRepository;
            _mapper = mapper;
        }
        public void Create(SlotsDTO entity) => _slotsRepository.Create(_mapper.Map<Slots>(entity));


        public void Delete(int id) => _slotsRepository.Delete(id);
             

        public SlotsDTO Get(int id) => _mapper.Map<SlotsDTO>(_slotsRepository.Get(id));


        public List<SlotsDTO> GetAll() => _mapper.Map<List<SlotsDTO>>(_slotsRepository.GetAll());


        public void Update(SlotsDTO entity) => _slotsRepository.Update(_mapper.Map<Slots>(entity));
    }
}
