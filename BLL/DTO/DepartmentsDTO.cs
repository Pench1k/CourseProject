using DAL.Models;

namespace BLL.DTO
{
    public class DepartmentsDTO
    {
       
        public int Id { get; set; }       
        public string NameDepartment { get; set; }

        public int FacultyesId { get; set; }
        public FacultyesDTO Faculty { get; set; }

        public List<Groups> GroupsAtTheDepartment { get; set; }

        public List<Workers> WorkerAtTheDepartment { get; set; }

        //Добавить поле замКафедры
    }
}
