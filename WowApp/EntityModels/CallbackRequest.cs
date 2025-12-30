using System.ComponentModel.DataAnnotations;

namespace WowApp.EntityModels
{
    public class CallbackRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Comment { get; set; }

        public bool IsCulture { get; set; } = false;
        public DateTime CreatedUtc { get; set; }
        public bool IsProcessed { get; set; } = false;
    }
}
