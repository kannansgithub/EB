using EB.Domain.Bases;
using EB.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EB.Domain.Entities;

public class Address : BaseEntityAdvance, IAggregateRoot
{
    public required string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; } = null!;
    public string AddressLine3 { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Website { get; set; } = null!;
    public string Fax { get; set; } = null!;
    public bool IsPrimary { get; set; } = false;

    [ForeignKey(nameof(Store))]
    public string? StoreId { get; set; }

    [ForeignKey(nameof(Vendor))]
    public string? VendorId { get; set; }

    [ForeignKey(nameof(Customer))]
    public string? CustomerId { get; set; } 
    [ForeignKey(nameof(Client))]
    public string? ClientId { get; set; }

    //public Address() : base() { } //for EF Core
    //public Address(
    //    string? userId,
    //    string code,
    //    string name,
    //    string? description,
    //    string addressLine1,
    //    string addressLine2,
    //    string addressLine3,
    //    string street,
    //    string city,
    //    string region,
    //    string zipCode,
    //    string? country,
    //    string phone,
    //    string email,
    //    string? website,
    //    string? fax,
    //    bool isPrimary) : base(userId, code, name, description) {
    //    AddressLine1 = addressLine1.Trim();
    //    AddressLine2 = addressLine2.Trim();
    //    AddressLine3 = addressLine3.Trim();
    //    Street = street.Trim();
    //    City = city.Trim();
    //    Region = region.Trim();
    //    ZipCode = zipCode.Trim();
    //    Country = country?.Trim();
    //    Phone = phone.Trim();
    //    Email = email.Trim();
    //    Website = website?.Trim();
    //    Fax = fax?.Trim();
    //    IsPrimary = isPrimary;
    //}
    //public void Update(
    //    string? userId,
    //    string code,
    //    string name,
    //    string? description,
    //    string addressLine1,
    //    string addressLine2,
    //    string addressLine3,
    //    string street,
    //    string city,
    //    string region,
    //    string zipCode,
    //    string? country,
    //    string phone,
    //    string email,
    //    string? website,
    //    string? fax,
    //    bool isPrimary)
    //{
    //    Code = code.Trim();
    //    Name = name.Trim(); 
    //    Description = description?.Trim();
    //    AddressLine1 = addressLine1.Trim();
    //    AddressLine2 = addressLine2.Trim();
    //    AddressLine3 = addressLine3.Trim();
    //    Street = street.Trim();
    //    City = city.Trim();
    //    Region = region.Trim();
    //    ZipCode = zipCode.Trim();
    //    Country = country?.Trim();
    //    Phone = phone.Trim();
    //    Email = email.Trim();
    //    Website = website?.Trim();
    //    Fax = fax?.Trim();
    //    IsPrimary = isPrimary;

    //    SetAsUpdated(userId);
    //}
    //public void Delete(string? userId)
    //{
    //    SetAsDeleted(userId);
    //}
}
