using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class FacultyesService : IFacultyesService
    {
        private readonly IFacultyesRepository _facultyesRepository;
        private readonly IMapper _mapper;

        public FacultyesService(IFacultyesRepository faultyesRepository, IMapper mapper)
        {
            _facultyesRepository = faultyesRepository;
            _mapper = mapper;
        }

        public void Create(FacultyesDTO entity) => _facultyesRepository.Create(_mapper.Map<Facultyes>(entity));


        public void Delete(int id) => _facultyesRepository.Delete(id);

        public FacultyesDTO Get(int id) => _mapper.Map<FacultyesDTO>(_facultyesRepository.Get(id)); 


        public List<FacultyesDTO> GetAll() => _mapper.Map<List<FacultyesDTO>>(_facultyesRepository.GetAll());

        public void Update(FacultyesDTO entity) => _facultyesRepository.Update(_mapper.Map<Facultyes>(entity));

    }
}
