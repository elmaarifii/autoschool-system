namespace AutoshkollaAPI.Models
{
    public class AvailableSlot : IEntity
    {
        public int Id { get; set; }
        public string InstructorName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public bool IsBooked { get; set; }
    }
}
