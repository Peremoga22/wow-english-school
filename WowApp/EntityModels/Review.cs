using System.ComponentModel.DataAnnotations;

namespace WowApp.EntityModels
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть ім’я та прізвище")]
        [StringLength(100, ErrorMessage = "Ім'я не повинно перевищувати 100 символів")]
        [MinLength(3, ErrorMessage = "Ім'я занадто коротке")]
        public string ClientName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Відгук є обовʼязковим")]
        [StringLength(180, ErrorMessage = "Відгук не може перевищувати 180 символів")]
        public string Content { get; set; } = string.Empty;
        public DateOnly ReviewDate { get; set;  }
        [Range(1, 5, ErrorMessage = "Оберіть оцінку")]
        public int Rating { get; set; } = 5;
        public bool IsCulture { get; set; } = false;
        public string DiscussionLink { get; set; } = string.Empty;
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; } = default!;
    }
}
