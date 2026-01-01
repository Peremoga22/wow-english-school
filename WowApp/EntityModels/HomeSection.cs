using System.ComponentModel.DataAnnotations;

namespace WowApp.EntityModels
{
    public class HomeSection
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string PhotoTitle { get; set; } = string.Empty;

        [Required, StringLength(600)]
        public string PhotoText { get; set; } = string.Empty;

        [Required, StringLength(260)]
        public string ImgLeftPath { get; set; } = string.Empty;

        [Required, StringLength(260)]
        public string ImgCenterPath { get; set; } = string.Empty;

        [Required, StringLength(260)]
        public string ImgRightPath { get; set; } = string.Empty;

        [StringLength(120)]
        public string ChristmasTitle { get; set; } = "Написпти привітання!";

        [StringLength(600)]
        public string ChristmasText { get; set; } = string.Empty;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public bool IsCulture { get; set; } = false;
    }
}
