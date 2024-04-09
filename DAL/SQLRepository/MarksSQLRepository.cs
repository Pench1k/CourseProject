using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class MarksSQLRepository : IMarksRepository
    {
        private readonly ApplicationDbContext _context;

        public void Create(Marks entity)
        {
            _context.Marks.Add(entity);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var deletMarks = _context.Marks.Find(id);
            if (deletMarks != null)
            {
                _context.Marks.Remove(deletMarks);  
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не существует");
        }

        public Marks Get(int id) => _context.Marks.Find(id);
        
        public List<Marks> GetAll() => _context.Marks.ToList();
       
        public void Update(Marks entity)
        {
            _context.Marks.Update(entity);
            _context.SaveChanges();
        }
    }
}
