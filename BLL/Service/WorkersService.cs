using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class WorkersService : IWorkersService
    {
        private readonly IWorkersRepository _workersRepository;
        private readonly IMapper _mapper;
        public WorkersService(IWorkersRepository workersRepository, IMapper mapper)
        { 
            _workersRepository = workersRepository;
            _mapper = mapper;
        }
        public void Create(WorkersDTO entity) => _workersRepository.Create(_mapper.Map<Workers>(entity));


        public void Delete(int id) => _workersRepository.Delete(id);


        public WorkersDTO Get(int id) => _mapper.Map<WorkersDTO>(_workersRepository.Get(id));


        public List<WorkersDTO> GetAll() => _mapper.Map<List<WorkersDTO>>(_workersRepository.GetAll());


        public void Update(WorkersDTO entity) => _workersRepository.Update(_mapper.Map<Workers>(entity));
    }
}
