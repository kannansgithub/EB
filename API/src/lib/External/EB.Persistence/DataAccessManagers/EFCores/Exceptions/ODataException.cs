
namespace EB.Persistence.DataAccessManagers.EFCores.Exceptions;

public class ODataException : Exception
{
    public ODataException() { }

    public ODataException(string message) : base(message) { }

    public ODataException(string message, Exception innerException) : base(message, innerException) { }
}

