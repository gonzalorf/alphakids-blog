namespace AlphaKids.Domain.Rates;

public class RateInvalidValueException : Exception
{
    public RateInvalidValueException(string message) : base(message) { }
}
