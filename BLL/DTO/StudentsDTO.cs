using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.DTO
{
    public class StudentsDTO
    {
        public int StudentId { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public string CardNumber { get; set; }

        public int GroupId { get; set; }
        public Groups Groups { get; set; }
    }
}
