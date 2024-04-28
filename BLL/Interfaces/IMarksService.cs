using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IMarksService : IService<MarksDTO>
    {
        MarksDTO GetMarkByStudentIdAndPairId(int studentId, int pairId);
    }
}
