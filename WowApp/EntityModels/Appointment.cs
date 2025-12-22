using System.ComponentModel.DataAnnotations;

using WowApp.Data;
using WowApp.EntityModels;

namespace WowApp.EntityModels
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть ім’я та прізвище")]
        [StringLength(100, ErrorMessage = "Ім'я не повинно перевищувати 100 символів")]
        [MinLength(3, ErrorMessage = "Ім'я занадто коротке")]
        public string ClientName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введіть номер телефону")]
        [RegularExpression(@"^(\+380|0)\d{9}$", ErrorMessage = "Формат телефону: +380XXXXXXXXX")]
        public string ClientPhone { get; set; } = string.Empty;               
        public DateOnly AppointmentDate { get; set; } 
        public string Message { get; set; } = string.Empty;
        public bool IsCulture { get; set; } = false;
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public List<ServiceClient> ServiceClients { get; set; } = new();
        public List<Portfolio> Portfolios { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
