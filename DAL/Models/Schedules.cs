using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Schedules
    {
        [Key]
        public int Id { get; set; }

        public int? WorkerId { get; set; }
        public Workers? Worker { get; set; }

        public List<GroupsSchedules> Groups { get; set; }

        public int DisciplinesId { get; set; }
        public Disciplines Disciplines { get; set; }    

        public TypeSchedule TypeSchedule { get; set; }

        public List<SlotsSchedules> Slots { get; set; }
    }

    public enum TypeSchedule
    { 
        Лекция,
        Практика
    }

}