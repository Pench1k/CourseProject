using Microsoft.AspNetCore.Identity;

namespace BLL.DTO
{
    public class UserDTO : IdentityUser
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
    }
}
