using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Schedule
    {
        [Key]
        public int SheduleId { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int GroupId { get; set; }
       
        public List<Groups> Groups { get; set; }

        public int DisciplineId { get; set; }
        public Disciplines Disciplines { get; set; }

        public TypeSchedule typeSchedule { get; set; }

        public List<Slots> Slots { get; set; }

        public enum TypeSchedule
        {
            Лекция,
            Практика,
        }

    }
}
