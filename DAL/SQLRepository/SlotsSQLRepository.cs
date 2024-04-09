using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class SlotsSQLRepository : ISlotsRepository
    {
        private readonly ApplicationDbContext _context;

        public SlotsSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Slots entity)
        {
            _context.Slots.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           var deletSlots =  _context.Slots.Find(id);
            if(deletSlots != null) {
                _context.Slots.Remove(deletSlots);  
                _context.SaveChanges();
            }

        }

        public Slots Get(int id) => _context.Slots.Find(id);
      

        public List<Slots> GetAll() => _context.Slots.ToList();
        

        public void Update(Slots entity)
        {
            _context.Slots.Update(entity);
            _context.SaveChanges();
        }
    }
}
