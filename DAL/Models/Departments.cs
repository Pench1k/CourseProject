using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        //Добавить уникальность поля//
        public string NameDepartment { get; set; }

        public int FacultyId { get; set; }
        public Facultyes Faculty{ get; set; }

        public List<Groups> GroupsAtTheDepartment { get; set; }

        public List<Workers> WorkerAtTheDepartment { get; set;}

        //Добавить поле замКафедры
    }
}
