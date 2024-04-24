

using BLL.ViewModel;

namespace BLL.Interfaces
{
    public interface IStudyService
    {
        Task<List<SlotsShow>> GetScheduleGroup(string id);
    }
}
