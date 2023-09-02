namespace NanoBlogEngine.Domain.Posts;

public class RateInvalidValueException : ApplicationException
{
    public RateInvalidValueException(string message) : base(message) { }
}
