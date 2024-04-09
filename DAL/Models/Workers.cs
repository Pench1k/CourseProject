using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Workers
    {
        [Key]
        public int WorkerId { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int DepartmentId {get; set; }

        public Departments Department { get; set; }

        public List<Schedules> Schedules { get; set; }  
    }
}
