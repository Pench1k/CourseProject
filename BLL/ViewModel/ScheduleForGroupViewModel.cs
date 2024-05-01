using DAL.Models;
using System.Runtime.CompilerServices;

namespace BLL.ViewModel
{
    public class ScheduleForGroupViewModel
    {        
        public int WorkerId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public int ScheduleId {get; set;}
        public int GroupId { get; set;}
        public string DisciplineName {get; set;}       
        public TypeSchedule TypeSchedule {get; set;}
    }
}
