namespace BLL.ViewModel
{
    public class StudentStatistics
    {
        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public double? AverageMark { get; set; }
        public int Absences { get; set; }
    }
}
