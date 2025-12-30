using System.ComponentModel.DataAnnotations;

using WowApp.Data;

namespace WowApp.ModelsDTOs
{
    public class RequestBaseDto
    {
        [Required(ErrorMessage = "Введіть ім’я та прізвище")]
        [StringLength(100)]
        [MinLength(3)]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введіть номер телефону")]
        [RegularExpression(@"^(\+380|0)\d{9}$",
            ErrorMessage = "Формат телефону: +380XXXXXXXXX або 0XXXXXXXXX")]
        public string ClientPhone { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Message { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
