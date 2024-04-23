using DAL.Models;

namespace DAL.Interfaces
{
    public interface IWorkersRepository : IRepository<Workers>
    {
        Workers Find(Func<Workers, bool> predicate);    

    }
}
