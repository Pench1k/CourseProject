

using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMarksRepository : IRepository<Marks>
    {
        public Marks Find(Func<Marks, bool> predicate);
    }
}
