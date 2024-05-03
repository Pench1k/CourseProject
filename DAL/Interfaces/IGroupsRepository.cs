
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IGroupsRepository : IRepository<Groups>
    {
        Groups Find(Func<Groups, bool> predicate);
        List<Groups> FindAll(Func<Groups, bool> predicate);
    }
}
