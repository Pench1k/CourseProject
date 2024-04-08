using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class SlotsSchedules
    {
        [Key]
        public int SlotSchedulesId { get; set; }

        public int ScheduleId { get; set; }
        public List<Schedule> Schedules { get; set; }

        public int SlotId { get; set; }
        public List<Slots> Slots { get; set; }

    }
}
