using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DAL.SQLRepository
{
    public class MarksSQLRepository : IMarksRepository
    {
        private readonly ApplicationDbContext _context;
        public MarksSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
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

        public Marks Find(Func<Marks, bool> predicate)
        {
            return _context.Marks.AsNoTracking().FirstOrDefault(predicate);
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
