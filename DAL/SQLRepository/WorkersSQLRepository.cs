using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class WorkersSQLRepository : IWorkersRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkersSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Workers entity)
        {
            _context.Workers.Add(entity);   
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletWorker = _context.Workers.Find(id);
            if (deletWorker != null)
            {
                _context.Workers.Remove(deletWorker);
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не существует");
        }

        public Workers Find(Func<Workers, bool> predicate)
        {
            return _context.Workers.FirstOrDefault(predicate);
        }

        public Workers Get(int id) => _context.Workers.Find(id);
        

        public List<Workers> GetAll() => _context.Workers.ToList();
        
        public void Update(Workers entity)
        {
            _context.Workers.Update(entity);
            _context.SaveChanges();
        }
    }
}
