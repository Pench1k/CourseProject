using DAL.Models;

namespace BLL.DTO
{
    public class MarksDTO
    {
        public int MarksId { get; set; }

        public int MarksCount { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int PairsId { get; set; }
        public Pairs Pairs { get; set; }
    }
}
