using DAL.Models;

namespace BLL.ViewModel
{
    public class SlotsShow
    {
        public int DayOfTheWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string GroupName { get; set; }
        public int? Course { get; set; }
        public int? GroupNumber { get; set; }
        public string WorkerSurname { get; set; }
        public TypeSchedule? TypeSchedule { get; set; }
        public string DisciplineName { get; set; }
        public int? WorkerId { get; set; }
    }
}
