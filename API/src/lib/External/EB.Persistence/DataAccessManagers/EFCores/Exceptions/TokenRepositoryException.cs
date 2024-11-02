
namespace EB.Persistence.DataAccessManagers.EFCores.Exceptions;

public class TokenRepositoryException : Exception
{
    public TokenRepositoryException() { }

    public TokenRepositoryException(string message) : base(message) { }

    public TokenRepositoryException(string message, Exception innerException) : base(message, innerException) { }
}
