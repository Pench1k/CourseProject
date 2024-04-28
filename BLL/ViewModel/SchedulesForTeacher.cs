using DAL.Models;

namespace BLL.ViewModel
{
    public class SchedulesForTeacher
    {
        public int? WorkerId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Course {  get; set; }
        public int GroupNumber { get; set; }
        public string DisciplineName { get; set; }
        public int ScheduleId { get; set; }
        public TypeSchedule TypeSchedule { get; set; }
    }
}
