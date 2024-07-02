using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class WorkersDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int DepartmentId { get; set; }

        public Departments Department { get; set; }

        public List<Schedules> Schedules { get; set; }
    }
}
