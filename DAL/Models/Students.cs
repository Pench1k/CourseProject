using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Students 
    {
        [Key]
        public int StudentId { get; set; }

        public string UserId { get; set; } 
        public IdentityUser User { get; set; }

        public string CardNumber { get; set; }

        public int GroupId { get; set; }    
        public Groups Groups { get; set; }
    }
}
