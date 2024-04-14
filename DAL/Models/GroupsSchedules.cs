namespace DAL.Models
{
    public class GroupsSchedules
    {
        public int GroupsId { get; set; }
        public int SchedulesId { get; set; }

        public Groups Groups { get; set; }  
        public Schedules Schedules { get; set; }
    }
}
