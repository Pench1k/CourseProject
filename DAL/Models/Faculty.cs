using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        
        public string NameFaculty { get; set; }

        public List<Department> DepartmentsAtTheFaculty { get; set; }

        //Поле декан добавить//
    }
}
