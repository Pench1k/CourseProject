
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class MarksSerivce : IMarksService
    {
        private readonly IMarksRepository _marksRepository;
        private readonly IMapper _mapper;

        public void Create(MarksDTO entity) => _marksRepository.Create(_mapper.Map<Marks>(entity));


        public void Delete(int id) => _marksRepository.Delete(id);


        public MarksDTO Get(int id) => _mapper.Map<MarksDTO>(_marksRepository.Get(id));


        public List<MarksDTO> GetAll() => _mapper.Map<List<MarksDTO>>(_marksRepository.GetAll());



        public void Update(MarksDTO entity) => _marksRepository.Update(_mapper.Map<Marks>(entity));
    }
}
