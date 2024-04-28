
using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.SQLRepository
{
    public class SchedulesSQLRepository : ISchedulesRepository
    {
        private readonly ApplicationDbContext _context;

        public SchedulesSQLRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public void Create(Schedules entity)
        {
            _context.Schedules.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletSchedule = _context.Schedules.Find(id);
            if (deletSchedule != null) {
                _context.Schedules.Remove(deletSchedule);
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не существует");
        }

        public Schedules Get(int id) => _context.Schedules.Find(id);




        public List<Schedules> GetAll() => _context.Schedules.ToList();
        


        public void Update(Schedules entity)
        {
            _context.Schedules.Update(entity);
            _context.SaveChanges();
        }
    }
}
