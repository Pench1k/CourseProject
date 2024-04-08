using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Disciplines
    {
        [Key]
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
    }
}
