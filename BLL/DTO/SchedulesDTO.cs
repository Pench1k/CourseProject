

using DAL.Models;

namespace BLL.DTO
{
    public class SchedulesDTO
    {
        public int ScheduleId { get; set; }

        public int WorkerId { get; set; }
        public Workers Worker { get; set; }

        public List<Groups> Groups { get; set; }

        public int DisciplinesId { get; set; }
        public DisciplinesDTO Disciplines { get; set; }

        public TypeSchedule TypeSchedule { get; set; }

        public List<SlotsSchedules> Slots { get; set; }
    }
}
