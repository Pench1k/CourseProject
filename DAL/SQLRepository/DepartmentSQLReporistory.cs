using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using System.Data;

namespace DAL.SQLRepository
{
    public class DepartmentSQLReporistory : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentSQLReporistory(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Departments entity)
        {
            _context.Departments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteDepartments = _context.Departments.Find(id); 
            if(deleteDepartments != null)
            {
                _context.Departments.Remove(deleteDepartments);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Такой записи не существует");
            }
        }

        public Departments? Get(int id)
        {
            return _context.Departments.Find(id);
        }

        public List<Departments> GetAll() => _context.Departments.ToList();

        public void Update(Departments entity)
        {
            _context.Departments.Update(entity);
            _context.SaveChanges();
        }
    }
}
