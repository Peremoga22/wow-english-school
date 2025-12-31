namespace WowApp.ModelsDTOs
{
    public class CalendarRowDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }       
        public string ClientName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public  string Group { get; set; } = string.Empty;
        public string TitleCard { get; set; } = string.Empty;
        public string DescriptionCard { get; set; } = string.Empty;       
        public decimal? Price { get; set; }
        public bool IsCompleted { get; set; }
    }
}
