using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public string? Surname { get; set; } 
        public string? Name { get; set; }
        public string? MiddleName { get; set; }  
    }
}
