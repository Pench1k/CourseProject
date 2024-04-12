using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class PairsService : IPairsService
    {
        private readonly IPairsRepository _pairsRepository;
        private readonly IMapper _mapper;

        public PairsService(IPairsRepository pairsRepository, IMapper mapper)
        {
            _pairsRepository = pairsRepository;
            _mapper = mapper;
        }
        public void Create(PairsDTO entity) => _pairsRepository.Create(_mapper.Map<Pairs>(entity));


        public void Delete(int id) => _pairsRepository.Delete(id);


        public PairsDTO Get(int id) => _mapper.Map<PairsDTO>(_pairsRepository.Get(id));


        public List<PairsDTO> GetAll() => _mapper.Map<List<PairsDTO>>(_pairsRepository.GetAll());


        public void Update(PairsDTO entity) => _pairsRepository.Update(_mapper.Map<Pairs>(entity));
    }
}
