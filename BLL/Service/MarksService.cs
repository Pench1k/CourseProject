using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service
{
    public class MarksService : IMarksService
    {
        private readonly IMarksRepository _marksRepository;
        private readonly IMapper _mapper;

        public MarksService(IMarksRepository marksRepository, IMapper mapper)
        {
            _marksRepository = marksRepository;
            _mapper = mapper;
        }


        public void Create(MarksDTO entity) => _marksRepository.Create(_mapper.Map<Marks>(entity));


        public void Delete(int id) => _marksRepository.Delete(id);


        public MarksDTO Get(int id) => _mapper.Map<MarksDTO>(_marksRepository.Get(id));


        public List<MarksDTO> GetAll() => _mapper.Map<List<MarksDTO>>(_marksRepository.GetAll());



        public void Update(MarksDTO entity)
        {
            _marksRepository.Update(_mapper.Map<Marks>(entity));
        }

        public MarksDTO GetMarkByStudentIdAndPairId(int studentId, int pairId)
        {
            return _mapper.Map<MarksDTO>(_marksRepository.Find(x => x.StudentId == studentId && x.PairsId == pairId));
        }
    }
}
