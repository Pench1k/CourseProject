using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Facultyes
    {
        [Key]
        public int Id { get; set; }
        
        public string NameFaculty { get; set; }

        public List<Departments> DepartmentsAtTheFaculty { get; set; }

        //Поле декан добавить//
    }
}
