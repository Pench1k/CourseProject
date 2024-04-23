
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IGroupsReporitory : IRepository<Groups>
    {
        Groups Find(Func<Groups, bool> predicate);

    }
}
