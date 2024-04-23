
using DAL.Models;

namespace BLL.DTO
{
    public class GroupsDTO
    {
        public int GroupId { get; set; }
        public string NameGroup { get; set; }
        public int NumberGroup { get; set; }
        public int Course { get; set; }

        public int DepartmentId { get; set; }
        public Departments Department { get; set; }

        public List<Students> Students { get; set; }

        public List<Schedules> Scheduls { get; set; }

        public override string ToString()
        {
            return NameGroup + " - " + Course.ToString() + NumberGroup;
        }
    }
}
