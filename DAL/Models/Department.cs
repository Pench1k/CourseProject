using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        //Добавить уникальность поля//
        public string NameDepartment { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty{ get; set; }

        public List<Groups> GroupsAtTheDepartment { get; set; }

        public List<Worker> WorkerAtTheDepartment { get; set;}

        //Добавить поле замКафедры
    }
}
