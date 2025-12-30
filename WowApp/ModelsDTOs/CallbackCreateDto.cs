using System.ComponentModel.DataAnnotations;

namespace WowApp.ModelsDTOs
{
    public class CallbackCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; } = "";

        [Required]
        public string ClientPhone { get; set; } = "";

        public string? Message { get; set; }
    }
}
