
namespace EB.Infrastructure.DocumentManagers;

public class DocumentManagerException : Exception
{
    public DocumentManagerException() { }

    public DocumentManagerException(string message) : base(message) { }

    public DocumentManagerException(string message, Exception innerException) : base(message, innerException) { }
}
