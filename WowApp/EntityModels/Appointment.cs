using System.ComponentModel.DataAnnotations;

using WowApp.Data;
using WowApp.EntityModels;

namespace WowApp.EntityModels
{
    public class Appointment
    {
        public int Id { get; set; }
               
        [Required(ErrorMessage = "Введіть ім’я та прізвище")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Ім’я повинно містити від 3 до 100 символів")]
        public string ClientName { get; set; } = string.Empty;
               
        [Required(ErrorMessage = "Введіть номер телефону")]
        [RegularExpression(@"^(\+380|0)\d{9}$",
            ErrorMessage = "Формат телефону: +380XXXXXXXXX або 0XXXXXXXXX")]
        public string ClientPhone { get; set; } = string.Empty;
              
      
        public DateOnly AppointmentDate { get; set; }
              
        [StringLength(500, ErrorMessage = "Повідомлення не повинно перевищувати 500 символів")]
        public string? Message { get; set; }
              
        public bool IsCulture { get; set; } = false;              
      
        public string Group { get; set; } = string.Empty;         
       
        public string ServiceTitle { get; set; } = string.Empty;

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
               
        public List<ServiceClient> ServiceClients { get; set; } = new();
        public List<Portfolio> Portfolios { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
