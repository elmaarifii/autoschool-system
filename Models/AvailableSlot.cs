namespace AutoshkollaAPI.Models
{
    public class AvailableSlot : IEntity
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public bool IsBooked { get; set; }
    }
}