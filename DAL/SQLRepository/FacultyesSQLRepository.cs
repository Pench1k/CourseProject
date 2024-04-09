using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQLRepository
{
    public class FacultyesSQLRepository : IFacultyesRepository
    {
        private readonly ApplicationDbContext _context;
        public FacultyesSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Facultyes entity)
        {
            _context.Facultyes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletFacultyes = _context.Facultyes.Find(id);
            if (deletFacultyes != null)
            {
                _context.Facultyes.Remove(deletFacultyes);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Такой записи больше нету");
            }
        }

        public Facultyes? Get(int id) => _context.Facultyes.Find(id);
       

        public List<Facultyes> GetAll() => _context.Facultyes.ToList();


        public void Update(Facultyes entity)
        {
            _context.Facultyes.Update(entity);  
            _context.SaveChanges(); 
        }
    }
}
