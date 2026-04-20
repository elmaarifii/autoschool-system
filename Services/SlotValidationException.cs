namespace AutoshkollaAPI.Services;

public class SlotValidationException : Exception
{
    public SlotValidationException(string message) : base(message)
    {
    }
}
