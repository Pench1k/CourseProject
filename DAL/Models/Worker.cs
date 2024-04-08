using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int DepartmentId {get; set; }
        public Department Department { get; set; }

    }
}
