using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.SQLRepository
{
    public class GroupsSQLRepository : IGroupsReporitory
    {
        private readonly ApplicationDbContext _context;

        public GroupsSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Groups entity)
        {
            _context.Groups.Add(entity);    
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteGroup = _context.Groups.Find(id);
            if (deleteGroup != null)
            {
                _context.Groups.Remove(deleteGroup);
                _context.SaveChanges();
            }
            else
                throw new Exception("Такой записи не существует");
        }

        public Groups Find(Func<Groups, bool> predicate)
        {
            return _context.Groups.FirstOrDefault(predicate);
        }

        public Groups? Get(int id) => _context.Groups.Find(id);
       

        public List<Groups> GetAll() => _context.Groups.ToList();
     
        public void Update(Groups entity)
        {
            _context.Groups.Update(entity);
            _context.SaveChanges();
        }
    }
}
