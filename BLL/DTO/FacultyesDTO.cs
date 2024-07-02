
using DAL.Models;

namespace BLL.DTO
{
    public class FacultyesDTO
    {
        public int Id { get; set; }

        public string NameFaculty { get; set; }

        public List<Departments> DepartmentsAtTheFaculty { get; set; }
    }
}
