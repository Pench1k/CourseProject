using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class SlotsSchedulesSQLRepository : ISlotsSchedulesRepository
    {
        private readonly ApplicationDbContext _context;
        public SlotsSchedulesSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(SlotsSchedules entity)
        {
            _context.SlotsSchedules.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletSlotsSchedules = _context.SlotsSchedules.Find(id);
            if (deletSlotsSchedules != null)
            {
                _context.SlotsSchedules.Remove(deletSlotsSchedules);
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не сущестует");

        }

        public SlotsSchedules Get(int id) => _context.SlotsSchedules.Find(id);


        public List<SlotsSchedules> GetAll() => _context.SlotsSchedules.ToList();
     
        public void Update(SlotsSchedules entity)
        {
            _context.SlotsSchedules.Update(entity);
            _context.SaveChanges();
        }
    }
}
