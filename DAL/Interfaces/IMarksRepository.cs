

using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IMarksRepository : IRepository<Marks>
    {
        Marks Find(Func<Marks, bool> predicate);
        List<Marks> FindAll(Func<Marks, bool> predicate);
        IQueryable<Marks> GetAllSecond();
    }
}
