using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string NameGroup {get; set; }
        public int NumberGroup {get; set; }
        public int CourseGroup {get; set; }
        public int DepartmentId { get; set; }   
        public Department Department { get; set; }
        
        public List<Student> Students { get; set; }

        public List<Schedule> Schedules { get; set; }
        //Добавить поле старосты
    }
}
