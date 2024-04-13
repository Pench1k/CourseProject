

using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsReporitory;
        private readonly IMapper _mapper;
        public StudentsService(IStudentsRepository studentsReporitory, IMapper mapper)
        {
            _studentsReporitory = studentsReporitory;
            _mapper = mapper;
        }
        public void Create(StudentsDTO entity) => _studentsReporitory.Create(_mapper.Map<Students>(entity));


        public void Delete(int id) => _studentsReporitory.Delete(id);



        public StudentsDTO Get(int id) => _mapper.Map<StudentsDTO>( _studentsReporitory.Get(id));


        public List<StudentsDTO> GetAll() => _mapper.Map<List<StudentsDTO>>(_studentsReporitory.GetAll());


        public void Update(StudentsDTO entity) => _studentsReporitory.Update(_mapper.Map<Students>(entity));
    }
}
