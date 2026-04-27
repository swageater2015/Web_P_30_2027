using System.ComponentModel.DataAnnotations;

namespace Hotel.Model
{
    public class Hotel_Room : EFModel
    {
        [Required(ErrorMessage = "Номер комнаты обязателен")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Номер должен быть от 1 до 10 символов")]
        [Display(Name = "Номер комнаты")]
        public string? RoomNumber { get; set; }

        [Required(ErrorMessage = "Этаж обязателен")]
        [Range(1, 30, ErrorMessage = "Этаж должен быть от 1 до 30")]
        [Display(Name = "Этаж")]
        public string? Floor { get; set; }

        [Required(ErrorMessage = "Корпус обязателен")]
        [Range(1, 10, ErrorMessage = "Корпус должен быть от 1 до 10")]
        [Display(Name = "Корпус")]
        public int Building { get; set; }

        [Required(ErrorMessage = "Категория обязательна")]
        [Display(Name = "Категория")]
        public string? Category { get; set; }

        [Display(Name = "Клиент")]
        public int? ClientId { get; set; }

        public Client? Client { get; set; }
    }
}