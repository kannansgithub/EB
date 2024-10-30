namespace EB.Domain.Shared;

public static class Helper
{
    public static string Currency = "INR";

    public static string GetInvoiceNumber(string prefix) => $"{prefix}{GetRandomInvoiceNumber()}";
    private static string GetRandomInvoiceNumber()
    {
        var random = new Random();
        var billNumber=random.Next(1,1000);
        var date = DateTime.UtcNow;
        return $"{date.Year%100}{date.Month}{date.Day}{billNumber}";
    }
}
