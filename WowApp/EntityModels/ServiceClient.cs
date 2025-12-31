namespace WowApp.EntityModels
{
    public class ServiceClient
    {
        public int Id { get; set; }
        public string TitleCard { get; set; } = string.Empty;
        public string DescriptionCard { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty;     
        public string LessonTime { get; set; } = string.Empty;
        public int AgeOfStudent { get; set; }
        public string Group { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsCulture { get; set; } = false;

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
