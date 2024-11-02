namespace EB.Infrastructure.NumberSequenceManagers;

public class NumberSequenceException : Exception
{
    public NumberSequenceException() { }

    public NumberSequenceException(string message) : base(message) { }

    public NumberSequenceException(string message, Exception innerException) : base(message, innerException) { }
}
