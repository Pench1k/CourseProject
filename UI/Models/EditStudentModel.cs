using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class EditStudentModel
    {
        public string UserId { get; set; }
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Отчество обязательно")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        public string NewPassword { get; set; }
    }
}
