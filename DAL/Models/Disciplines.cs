using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Disciplines
    {
        [Key]
        public int Id { get; set; }
        public string DisciplineName { get; set; }
    }
}
