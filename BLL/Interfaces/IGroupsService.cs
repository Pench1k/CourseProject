using BLL.DTO;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IGroupsService : IService<GroupsDTO>
    {
        List<GroupsDTO> FindAll(Func<Groups, bool> predicate);
    }
}
