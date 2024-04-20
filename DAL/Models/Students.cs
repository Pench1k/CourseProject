using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Students 
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } 
        public User User { get; set; }

        public string? CardNumber { get; set; }

        [ForeignKey("GroupsId")]
        public int GroupsId { get; set; }    
        public Groups Groups { get; set; }
    }
}
