using System.ComponentModel.DataAnnotations;

namespace Hotel.Model
{
    public class Client : EFModel
    {
        [Required(ErrorMessage = "Фамилия и имя обязательны")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ФИО должно быть от 2 до 100 символов")]
        [Display(Name = "Фамилия и имя")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Телефон должен быть от 10 до 20 символов")]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        [CustomValidation(typeof(Client), nameof(ValidateBirthDate))]
        public DateTime BirthDate { get; set; }

        public List<Hotel_Room> Hotel_Rooms { get; set; } = new();

        public static ValidationResult? ValidateBirthDate(DateTime birthDate, ValidationContext context)
        {
            if (birthDate > DateTime.Now)
            {
                return new ValidationResult("Дата рождения не может быть в будущем");
            }
            if (birthDate < DateTime.Now.AddYears(-120))
            {
                return new ValidationResult("Некорректная дата рождения");
            }
            return ValidationResult.Success;
        }
    }
}