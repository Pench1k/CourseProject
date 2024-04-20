using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ISchedulesService : IService<SchedulesDTO>
    {
        List<SchedulesDTO>? SchedulesWithDisciplineGetAll();
    }
}
