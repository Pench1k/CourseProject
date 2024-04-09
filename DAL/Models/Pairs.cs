namespace DAL.Models
{
    public class Pairs
    {
        public int PairsId { get; set; }

        public int SlotScheduleId { get; set; }

        public SlotsSchedules SlotSchedule { get; set; }

        public TypePair TypePair { get; set; }


    }
    public enum TypePair 
    {
        Заплонированая,
        Прошла,
        Отменена
    }

}
