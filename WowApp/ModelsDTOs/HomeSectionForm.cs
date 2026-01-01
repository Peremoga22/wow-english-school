using Microsoft.AspNetCore.Components.Forms;

namespace WowApp.ModelsDTOs
{
    public class HomeSectionForm
    {
        public IBrowserFile? LeftImage { get; set; }
        public IBrowserFile? CenterImage { get; set; }
        public IBrowserFile? RightImage { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool ShowChristmas { get; set; }
        public string? ChristmasTitle { get; set; }
        public string? ChristmasText { get; set; }
    }
}
