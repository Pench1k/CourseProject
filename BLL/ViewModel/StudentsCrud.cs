using System.ComponentModel.DataAnnotations;

namespace BLL.ViewModel
{
    public class StudentsCrud
    {
        public string UserId { get; set; }
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Логин не заполнен")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Имя не заполнено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия не заполнена")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Отчество не заполнено")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }      
    }


    public class StudentsEdit
    {
        public string UserId { get; set; }
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Логин не заполнен")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Имя не заполнено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия не заполнена")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Отчество не заполнено")]
        public string MiddleName { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
