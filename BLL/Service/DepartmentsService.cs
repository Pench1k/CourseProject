using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Interfaces;

namespace BLL.Service
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentsService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public void Create(DepartmentsDTO entity) => _departmentRepository.Create(_mapper.Map<Departments>(entity));


        public void Delete(int id) => _departmentRepository.Delete(id);
 

        public DepartmentsDTO Get(int id) => _mapper.Map<DepartmentsDTO>(_departmentRepository.Get(id));
        

        public List<DepartmentsDTO> GetAll() => _mapper.Map<List<DepartmentsDTO>>(_departmentRepository.GetAll());


        public void Update(DepartmentsDTO entity) => _departmentRepository.Update(_mapper.Map<Departments>(entity));

    }
}
