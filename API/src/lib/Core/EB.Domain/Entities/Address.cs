using EB.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Address:AuditableEntity
{
    public required string AddressLine1 { get; set; }
    public required string AddressLine2 { get; set; } = string.Empty;
    public required string AddressLine3 { get; set; } = string.Empty;
    public required string City { get; set; }
    public required string Region { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;

    //[ForeignKey(nameof(Store))]
    //public string StoreId { get; set; } = string.Empty;

    //[ForeignKey(nameof(Vendor))]
    //public string VendorId { get; set; } = string.Empty;

    //[ForeignKey(nameof(Customer))]
    //public string CustomerId { get; set; } = new string(string.Empty);

}
