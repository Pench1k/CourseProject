using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISlotsSchedulesRepository : IRepository<SlotsSchedules>
    {
        List<int> GetSlotsSchedulesIdsForDayOfWeek(int dayOfWeek);
    }
}
