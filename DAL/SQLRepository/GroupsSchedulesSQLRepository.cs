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
    public class GroupsSchedulesSQLRepository : IGroupsSchedulesRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupsSchedulesSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(GroupsSchedules entity)
        {
            _context.GroupsSchedules.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteGroup = _context.GroupsSchedules.Find(id);
            if (deleteGroup != null)
            {
                _context.GroupsSchedules.Remove(deleteGroup);
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не существует");
        }

        public GroupsSchedules Get(int id)
        {
           return _context.GroupsSchedules.Find(id);
        }

        public List<GroupsSchedules> GetAll()
        {
          return  _context.GroupsSchedules.ToList();
        }

        public void Update(GroupsSchedules entity)
        {
            _context.GroupsSchedules.Update(entity);
            _context.SaveChanges();
        }
    }
}
