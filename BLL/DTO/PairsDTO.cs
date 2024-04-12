using DAL.Models;

namespace BLL.DTO
{
    public class PairsDTO
    {
        public int PairsId { get; set; }

        public int SlotScheduleId { get; set; }

        public SlotsSchedules SlotSchedule { get; set; }

        public TypePair TypePair { get; set; }
    }
}
