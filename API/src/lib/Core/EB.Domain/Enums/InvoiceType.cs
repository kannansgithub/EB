namespace EB.Domain.Enums;

internal static class InvoiceType
{
    public static string PURCHASE { get;} = "PO";
    public static string PURCHASE_RETURN { get;} = "PR";
    public static string SALE { get;} = "SO";
    public static string SALE_RETURN { get;} = "SR";
}
