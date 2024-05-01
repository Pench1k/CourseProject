using DAL.Models;
using System.Text.Json.Serialization;

namespace BLL.DTO
{
    public class PairsDTO
    {
        public int Id { get; set; }

        public int SlotScheduleId { get; set; }

        //[JsonIgnore]
        //public SlotsSchedules SlotSchedule { get; set; }
        public DateTime Date { get; set; }
        public TypePair TypePair { get; set; }
    }
}
