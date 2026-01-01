using System.ComponentModel.DataAnnotations;

namespace WowApp.ModelsDTOs
{
    public class HomeSectionEditVm
    {

        public int? Id { get; set; }

        public string? Photo1Url { get; set; }
        public string? Photo2Url { get; set; }
        public string? Photo3Url { get; set; }

        [Required(ErrorMessage = "Вкажіть заголовок")]
        [StringLength(120)]
        public string PhotoTitle { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть текст")]
        [StringLength(500)]
        public string PhotoText { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть заголовок Різдва")]
        [StringLength(120)]
        public string ChristmasTitle { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть текст Різдва")]
        [StringLength(700)]
        public string ChristmasText { get; set; } = "";
    }
}
