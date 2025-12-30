using System.ComponentModel.DataAnnotations;

namespace WowApp.ModelsDTOs
{
    public class AppointmentCreateDto
    {
        [Required(ErrorMessage = "Введіть ім’я та прізвище")]
        [StringLength(100)]
        [MinLength(3)]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введіть номер телефону")]
        [RegularExpression(@"^(\+380|0)\d{9}$", ErrorMessage = "Формат телефону: +380XXXXXXXXX або 0XXXXXXXXX")]
        public string ClientPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Оберіть послугу")]
        [Range(1, int.MaxValue, ErrorMessage = "Оберіть послугу")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Оберіть категорію")]
        [Range(1, int.MaxValue, ErrorMessage = "Оберіть категорію")]
        public int TherapyId { get; set; }

        [Required(ErrorMessage = "Оберіть дату")]
        public DateOnly? AppointmentDate { get; set; }

        [StringLength(500)]
        public string Message { get; set; } = string.Empty;

        public bool IsCulture { get; set; }           
       
    }
}
