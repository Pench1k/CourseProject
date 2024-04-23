using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.ViewModel
{
    public class UserView
    {
        public User User { get; set; }
        public IList<string> Role {  get; set; }  
        public Workers? Workers { get; set; }
        public Students? Students { get; set; }
        public Groups? Groups { get; set; }
        public Facultyes Facultyes { get; set; }
        public Departments? Departments { get; set; }
    }
}
