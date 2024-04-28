using DAL.Models;

namespace BLL.DTO
{
    public class PairsDTO
    {
        public int Id { get; set; }

        public int SlotScheduleId { get; set; }

        public SlotsSchedules SlotSchedule { get; set; }
        public DateTime Date { get; set; }
        public TypePair TypePair { get; set; }
    }
}
