using DAL.Models;


namespace BLL.ViewModel
{
    public class StudentWithUser
    {
       public int StudentId {  get; set; }
       public int GroupId {  get; set; }

       public string UserId { get; set; }
       public string? Surname { get; set; }
       public string? Name { get; set; }
       public string? MiddleName { get; set; }
    }
}
