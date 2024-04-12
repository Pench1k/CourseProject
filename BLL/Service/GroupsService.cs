using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Service
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsReporitory _groupsReporitory;
        private readonly IMapper _mapper;
        public GroupsService(IGroupsReporitory groupsReporitory, IMapper mapper)
        {
            _groupsReporitory = groupsReporitory;
            _mapper = mapper;
        }

        public void Create(GroupsDTO entity) => _groupsReporitory.Create(_mapper.Map<Groups>(entity));



        public void Delete(int id) => _groupsReporitory.Delete(id);


        public GroupsDTO Get(int id) => _mapper.Map<GroupsDTO>(_groupsReporitory.Get(id));


        public List<GroupsDTO> GetAll() => _mapper.Map<List<GroupsDTO>>(_groupsReporitory.GetAll());


        public void Update(GroupsDTO entity) => _groupsReporitory.Update(_mapper.Map<Groups>(entity));
    }
}
