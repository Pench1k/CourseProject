using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DAL.SQLRepository
{
    public class DisciplinesSQLRepository : IDisciplinesReporistory
    {
        private readonly ApplicationDbContext _context;

        public DisciplinesSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Disciplines entity)
        {
            _context.Disciplines.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteDisciplines = _context.Disciplines.Find(id);
            if (deleteDisciplines != null)
            {
                _context.Disciplines.Remove(deleteDisciplines); 
                _context.SaveChanges();
            }
        }

        public Disciplines? Get(int id) => _context.Disciplines.Find(id);   

        public List<Disciplines> GetAll() => _context.Disciplines.ToList();

        public void Update(Disciplines entity)
        {
            _context.Disciplines.Update(entity);
            _context.SaveChanges();
        }
    }
}
