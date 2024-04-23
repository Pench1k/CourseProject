using DAL.Models;

namespace DAL.Interfaces
{
    public interface IStudentsRepository : IRepository<Students>
    {
        Students Find(Func<Students, bool> predicate);
    }
}
