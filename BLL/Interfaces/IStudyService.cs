

using BLL.DTO;
using BLL.ViewModel;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IStudyService
    {
        Task<List<SlotsShow>> GetScheduleGroup(string id);
        void GenerateSchedule(DateTime startDate, DateTime endDate);
        List<SchedulesForTeacher> GetSchedulesForWorker(int workerId);
        Task<List<StudentWithUser>> StudentWithUsers(int groupId);
        List<PairsDTO> GetPairDatesForSchedule(int scheduleId);
        Task<List<ScheduleForGroupViewModel>> GetSchedulesForGroup(int groupId);
        List<GroupsDTO> GetGroupsOnDepartments(int departmentId);
        Task<List<StudentStatistics>> GetStudentStatistics(int groupId, int schedulesId);
    }
}
