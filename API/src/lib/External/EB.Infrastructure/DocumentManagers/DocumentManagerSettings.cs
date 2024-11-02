
namespace EB.Infrastructure.DocumentManagers;

public class DocumentManagerSettings
{
    public string PathFolder { get; set; } = string.Empty;
    public int MaxFileSizeInMB { get; set; }
}
