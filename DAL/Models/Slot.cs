using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Slots
    {
        [Key]
        public int SlotId { get; set;}
        public TimeSpan StartSchedule { get; set;}
        public TimeSpan EndSchedule { get; set;}
        public int DayOfWeek { get; set;}

        public List<Schedule> Schedule { get; set;}     
    }
}

