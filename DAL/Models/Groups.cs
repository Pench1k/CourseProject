using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }    
        public string NameGroup { get; set; }
        public int NumberGroup { get; set; }
        public int Course { get; set; }

        public int DepartmentId { get; set; }
        public Departments Department { get;set; }

        public List<Students> Students { get; set; } 
        
        public List<Schedules> Scheduls { get; set; }
    }
}