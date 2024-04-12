using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class DisciplinesService : IDisciplinesService
    {
        private readonly IDisciplinesReporistory _disciplinesReporistory;
        private readonly IMapper _mapper;

        public DisciplinesService(IDisciplinesReporistory disciplinesReporistory, IMapper mapper)
        {
            _disciplinesReporistory = disciplinesReporistory;
            _mapper = mapper;
        }

        public void Create(DisciplinesDTO entity) => _disciplinesReporistory.Create(_mapper.Map<Disciplines>(entity));


        public void Delete(int id) => _disciplinesReporistory.Delete(id);


        public DisciplinesDTO Get(int id) => _mapper.Map<DisciplinesDTO>(_disciplinesReporistory.Get(id));



        public List<DisciplinesDTO> GetAll() => _mapper.Map<List<DisciplinesDTO>>(_disciplinesReporistory.GetAll());


        public void Update(DisciplinesDTO entity) => _disciplinesReporistory.Update(_mapper.Map<Disciplines>(entity));
    }
}
