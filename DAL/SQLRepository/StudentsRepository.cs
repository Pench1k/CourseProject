
using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentsRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void Create(Students entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var deletStudents = _context.Students.Find(id);
            if (deletStudents != null)
            {
                _context.Students.Remove(deletStudents);
                _context.SaveChanges();
            }
        }

        public Students Find(Func<Students, bool> predicate)
        {
            return _context.Students.FirstOrDefault(predicate);
        }

        public Students Get(int id) => _context.Students.Find(id);
       

        public List<Students> GetAll() => _context.Students.ToList();

  
        public void Update(Students entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();
        }
    }
}
