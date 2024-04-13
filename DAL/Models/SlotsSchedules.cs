using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class SlotsSchedules
    {
        [Key]
        public int Id { get; set; }
        
        public int SlotsId { get; set; }
        public Slots Slots { get; set; }

        public int SchedulesId { get; set; }
        public Schedules Schedules { get; set; }

        public List<Pairs> Pairs { get; set; }

    }
}
