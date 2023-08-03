namespace NanoBlogEngine.Domain.Posts;

public class RateInvalidValueException : Exception
{
    public RateInvalidValueException(string message) : base(message) { }
}
