namespace NanoBlogEngine.Domain.Rates.Exceptions;

public class RateInvalidValueException : ApplicationException
{
    public RateInvalidValueException(string message) : base(message) { }
}
