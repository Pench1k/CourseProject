
using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class PairsSQLRepository : IPairsRepository
    {
        private readonly ApplicationDbContext _context;

        public PairsSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Pairs entity)
        {
            _context.Pairs.Add(entity); 
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletPairs = _context.Pairs.Find(id);
            if (deletPairs != null)
            {
                _context.Pairs.Remove(deletPairs);  
                _context.SaveChanges();
            }
        }

        public Pairs? Get(int id) => _context.Pairs.Find(id);
    
        public List<Pairs> GetAll() => _context.Pairs.ToList(); 
        
        public void Update(Pairs entity)
        {
            _context.Pairs.Update(entity);
            _context.SaveChanges();
        }
    }
}
