using DAL.Models;

namespace BLL.DTO
{
    public class SlotsSchedulesDTO
    {
        public int SlotsSchedulesId { get; set; }

        public int SlotsId { get; set; }
        public Slots Slots { get; set; }

        public int SchedulesId { get; set; }
        public Schedules Schedules { get; set; }

        public List<Pairs> Pairs { get; set; }
    }
}
