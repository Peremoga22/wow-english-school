namespace WowApp.EntityModels
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string TitleCard { get; set; } = string.Empty;
        public string DescriptionCard { get; set; } = string.Empty;    
        public string Group { get; set; } = string.Empty;  
        public string ImgPath { get; set; } = string.Empty;
        public string ImgTeacherPath { get; set; } = string.Empty;
        public string VideoPath { get; set; } = string.Empty;
        public bool IsCulture { get; set; } = false;
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = default!;
    }
}
